using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Timers;

namespace DesktopFacebook.Logic
{
    public delegate void RefreshPostTextDelegate(object sender, EventArgs e);

    public class WorldClockLogic
    {
        private const string k_PhotoURL = "https://en.wikipedia.org/wiki/";
        private Timer m_Timer;
        private string m_AllHTML;
        private string m_AllHTMLEdited;
        private string m_CitysHtml;
        private string m_CurrentTime;
        private string m_AllHTMLPhotos;
        private string m_CurrentCityNameForURL;
        private string m_CurrentCity;
        private Dictionary<string, string> m_CityNameAndTime = null;

        public string CurrentCityMessage { get; private set; }

        public string CurrentPhotoURL { get; private set; }

        public List<string> GetListOfCitys { get; private set; }

        public event RefreshPostTextDelegate m_RefreshPostTextDelegate;

        public WorldClockLogic()
        {
        }

        public void SetListOfCitys()
        {
            int startIndex, endIndex;

            if (m_CityNameAndTime == null)
            {
                m_CityNameAndTime = new Dictionary<string, string>();
            }
            else
            {
                m_CityNameAndTime.Clear();
                GetListOfCitys.Clear();
            }

            try
            {
                getHtml();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Something wrong! Exception message: {0} ", ex.Message), ex);
            }

            m_AllHTMLEdited = m_AllHTML;
            endIndex = m_AllHTMLEdited.IndexOf("</a><span id=p");
            startIndex = endIndex;
            do
            {
                while (m_AllHTMLEdited[startIndex] != '>')
                {
                    startIndex--;
                }

                startIndex++;
                m_CitysHtml = m_AllHTMLEdited.Substring(startIndex, endIndex - startIndex);
                m_AllHTMLEdited = m_AllHTMLEdited.Remove(0, endIndex);
                startIndex = m_AllHTMLEdited.IndexOf("class=rbi>");
                m_CurrentTime = m_AllHTMLEdited.Substring(startIndex + 10, 9);
                m_AllHTMLEdited = m_AllHTMLEdited.Remove(0, startIndex + 18);
                m_CityNameAndTime.Add(m_CitysHtml, m_CurrentTime);
                endIndex = m_AllHTMLEdited.IndexOf("</a><span id=p");
                startIndex = endIndex;
            }
            while (endIndex > 0);

            GetListOfCitys = m_CityNameAndTime.Keys.ToList<string>();
        }

        public string GetPostCityAndTime()
        {
            return string.Format("The day and time at {0} is: {1}", m_CurrentCity, m_CityNameAndTime[m_CurrentCity]);
        }

        public bool IsSourcePhotoAvailable()
        {
            bool IsSourcePhotoAvailable = false;
            setCityNameForURL();
            try
            {
                string webAdress = string.Format("{0}{1}", k_PhotoURL, m_CurrentCityNameForURL);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(webAdress);
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                using (Stream context = res.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(context))
                    {
                        m_AllHTMLPhotos = reader.ReadToEnd();
                        IsSourcePhotoAvailable = true;
                    }
                }
            }
            finally
            {
                if (!IsSourcePhotoAvailable)
                {
                    CurrentCityMessage = string.Format("City photo: {0} - Source is unavailable", m_CurrentCity);
                }
            }

            return IsSourcePhotoAvailable;
        }

        public void StopRefreshTimer()
        {
            m_Timer.Stop();
        }

        public void StartRefreshTimer()
        {
            if (m_Timer == null)
            {
                initFirstTimer();
            }

            m_Timer.Start();
        }

        public bool IsAvailablePhotoInURL()
        {
            int end1, end2, end3, finalEnd;
            int start;
            bool StopSearch = false;
            bool IsPhotoFound = false;
            string photoURL;
            do
            {
                start = m_AllHTMLPhotos.IndexOf(@"src=""//upload") + 5;
                m_AllHTMLPhotos = m_AllHTMLPhotos.Remove(0, start);
                end1 = m_AllHTMLPhotos.IndexOf(".jpg\" width") + 4;
                end2 = m_AllHTMLPhotos.IndexOf(".JPG\" width") + 4;
                end3 = m_AllHTMLPhotos.IndexOf(@".png"" width") + 4;
                if (end1 == 3)
                {
                    end1 = 1000;
                }

                if (end2 == 3)
                {
                    end2 = 1000;
                }

                if (end3 == 3)
                {
                    end3 = 1000;
                }

                finalEnd = Math.Min(Math.Min(end1, end2), end3);
                if (finalEnd > 300 && finalEnd != 1000)
                {
                    m_AllHTMLPhotos = m_AllHTMLPhotos.Remove(0, 10);
                }
                else
                {
                    if (start > 0 && finalEnd - 4 > 0 && finalEnd != 1000)
                    {
                        photoURL = m_AllHTMLPhotos.Substring(0, finalEnd);
                        if (photoURL.ToLower().Contains(m_CurrentCityNameForURL.ToLower()))
                        {
                            CurrentPhotoURL = string.Format("https:{0}", photoURL);
                            CurrentCityMessage = string.Format("City photo: {0}", m_CurrentCity);
                            StopSearch = true;
                            IsPhotoFound = true;
                        }
                        else
                        {
                            m_AllHTMLPhotos = m_AllHTMLPhotos.Remove(0, finalEnd + 12);
                        }
                    }
                    else
                    {
                        CurrentCityMessage = string.Format("City photo: {0} - No source", m_CurrentCity);
                        StopSearch = true;
                    }
                }
            }
            while (!StopSearch);

            return IsPhotoFound;
        }

        public string SetCurrentCity
        {
            set
            {
                m_CurrentCity = value;
            }
        }

        private void initFirstTimer()
        {
            m_Timer = new Timer(TimeSpan.FromMinutes(0.5).TotalMilliseconds);
            m_Timer.AutoReset = true;
            m_Timer.Elapsed += new ElapsedEventHandler(refreshList);
        }

        private void refreshList(object sender, ElapsedEventArgs e)
        {
            SetListOfCitys();
            m_RefreshPostTextDelegate.Invoke(sender, e);
        }

        private void getHtml()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.timeanddate.com/worldclock/?low=c");
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            using (Stream context = res.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(context))
                {
                    m_AllHTML = reader.ReadToEnd();
                }
            }
        }

        private void setCityNameForURL()
        {
            m_CurrentCityNameForURL = m_CurrentCity;
            if (m_CurrentCityNameForURL.Contains("("))
            {
                m_CurrentCityNameForURL = m_CurrentCityNameForURL.Replace(" ", string.Empty);
                int start = m_CurrentCityNameForURL.IndexOf("(");
                int end = m_CurrentCityNameForURL.IndexOf(")");
                m_CurrentCityNameForURL = m_CurrentCityNameForURL.Remove(start, end - start);
            }

            if (m_CurrentCityNameForURL.Contains(" "))
            {
                m_CurrentCityNameForURL = m_CurrentCityNameForURL.Replace(' ', '_');
            }

            if (m_CurrentCityNameForURL.Contains("-"))
            {
                m_CurrentCityNameForURL = m_CurrentCityNameForURL.Replace('-', '_');
            }

            if (m_CurrentCityNameForURL.Contains("'s"))
            {
                m_CurrentCityNameForURL = m_CurrentCityNameForURL.Replace("'s", string.Empty);
            }
        }
    }
}
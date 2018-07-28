using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Logic
{
    public class FBLogic
    {
        private const int k_CollectionLimit = 555;

        public User m_LoggedInUser { get; private set; }

        private PhotosSearchByFilterLogic m_PhotosSearchByFilter;

        private WorldClockLogic m_WorldClockLogic;

        private ILogin m_Login = new FBLoginAdapter();

        public FBLogic()
        {
            FacebookService.s_CollectionLimit = k_CollectionLimit;
        }

        public void Login()
        {
            m_Login.Login();
            m_LoggedInUser = m_Login.LoggedInUser;
        }

        public string GetPostCityAndTime()
        {
            return m_WorldClockLogic.GetPostCityAndTime();
        }

        public string SetCurrentCity
        {
            set
            {
                m_WorldClockLogic.SetCurrentCity = value;
            }
        }

        public string CurrentPhotoURL
        {
            get
            {
                return m_WorldClockLogic.CurrentPhotoURL;
            }
        }

        public string CurrentCityMessage
        {
            get
            {
                return m_WorldClockLogic.CurrentCityMessage;
            }
        }

        public List<string> GetListOfCitys
        {
            get
            {
                return m_WorldClockLogic.GetListOfCitys;
            }
        }

        public IEnumerator<Photo> MyPhotosSearchByFilter(int i_NumSize, DateTime i_startDay, DateTime i_endDay, string i_Sorter)
        {
            IEnumerable<Photo> topPhotos = m_PhotosSearchByFilter.MyPhotosSearchByFilter(i_NumSize, i_startDay, i_endDay, i_Sorter);
            return topPhotos.GetEnumerator();
        }

        public int MaxAmountOfPicForUser()
        {
            return m_PhotosSearchByFilter.CountTotalAmountOfPics();
        }

        public void CreateWorldClockLogic(RefreshPostTextDelegate i_RefreshPostText)
        {
            m_WorldClockLogic = new WorldClockLogic();
            m_WorldClockLogic.m_RefreshPostTextDelegate += i_RefreshPostText;
        }

        public void CreatePhotosSearchByFilterLogic()
        {
            m_PhotosSearchByFilter = new PhotosSearchByFilterLogic(m_LoggedInUser);
        }

        public int GetAmountBySorterPerPhoto(Photo i_Photo)
        {
            return m_PhotosSearchByFilter.GetAmountBySorterPerPhoto(i_Photo);
        }

        public bool IsSourcePhotoAvailable()
        {
            return m_WorldClockLogic.IsSourcePhotoAvailable();
        }

        public bool IsAvailablePhotoInURL()
        {
            return m_WorldClockLogic.IsAvailablePhotoInURL();
        }

        public void SetListOfCitys()
        {
            m_WorldClockLogic.SetListOfCitys();
        }

        public void StartRefreshTimer()
        {
            m_WorldClockLogic.StartRefreshTimer();
        }

        public int GetAmountOfFiltered(int i_CurrentTag)
        {
            return m_PhotosSearchByFilter.getAmountOfFiltered(i_CurrentTag);
        }

        public void StopRefreshTimer()
        {
            m_WorldClockLogic.StopRefreshTimer();
        }

        public void PostStatus(string i_StatusToPost)
        {
            m_LoggedInUser.PostStatus(i_StatusToPost);
        }
    }
}

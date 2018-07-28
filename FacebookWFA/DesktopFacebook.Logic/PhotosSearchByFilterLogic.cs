using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Logic
{
    internal class PhotosSearchByFilterLogic
    {
        private readonly User r_LoggedInUser;

        private Enumerable<Photo> m_MyPhotoCollection;

        private ICountableSorter m_CountableSorter;

        internal PhotosSearchByFilterLogic(User i_LoggedInUser)
        {
            r_LoggedInUser = i_LoggedInUser;
        }

        private void defineSorter(string i_SortBy)
        {
            m_CountableSorter = SorterFactory.Create(i_SortBy);
        }

        internal Enumerable<Photo> MyPhotosSearchByFilter(int i_NumOfPics, DateTime i_StartDate, DateTime i_EndDate, string i_Sorter)
        {
            if (m_MyPhotoCollection != null && m_MyPhotoCollection.GetEnumerator().MoveNext())
            {
                m_MyPhotoCollection.GetEnumerator().Dispose();
            }

            List<Photo> m_MyPicsList = new List<Photo>();
            defineSorter(i_Sorter);
            int photosCounter = 1;
            foreach (Album currAlbum in r_LoggedInUser.Albums)
            {
                foreach (Photo currPhoto in currAlbum.Photos)
                {
                    if (currPhoto.CreatedTime.Value.Date >= i_StartDate.Date && currPhoto.CreatedTime.Value.Date <= i_EndDate.Date)
                    {
                        if (photosCounter <= i_NumOfPics)
                        {
                            photosCounter++;
                            insertPhotoOrderBySorter(m_MyPicsList, currPhoto);
                        }
                        else if (m_CountableSorter.CompareBySorter(currPhoto, m_MyPicsList.Last()))
                        {
                            m_MyPicsList.RemoveAt(i_NumOfPics - 1);
                            insertPhotoOrderBySorter(m_MyPicsList, currPhoto);
                        }
                    }
                }
            }

            m_MyPhotoCollection = new Enumerable<Photo>(m_MyPicsList);
            return m_MyPhotoCollection;
        }

        private void insertPhotoOrderBySorter(List<Photo> io_myPicsList, Photo i_Photo)
        {
            bool isInserted = false;
            int photoListIndex = 0;
            foreach (Photo currentPhoto in io_myPicsList)
            {
                if (m_CountableSorter.CompareBySorter(i_Photo, currentPhoto))
                {
                    isInserted = true;
                    io_myPicsList.Insert(photoListIndex, i_Photo);
                    break;
                }

                photoListIndex++;
            }

            if (!isInserted)
            {
                io_myPicsList.Add(i_Photo);
            }
        }

        internal int GetAmountBySorterPerPhoto(Photo i_Photo)
        {
            return m_CountableSorter.GetAmount(i_Photo);
        }

        internal int getAmountOfFiltered(int i_CurrentTag)
        {
            int run = -1;
            IEnumerator<Photo> my_List = m_MyPhotoCollection.GetEnumerator();
            my_List.Reset();
            while (run < i_CurrentTag)
            {
                my_List.MoveNext();
                run++;
            }

            return GetAmountBySorterPerPhoto(my_List.Current);
        }

        internal int CountTotalAmountOfPics()
        {
            int countAmountOfPics = 0;
            foreach (Album currAlbum in r_LoggedInUser.Albums)
            {
                countAmountOfPics += (int)currAlbum.Count;
            }

            return countAmountOfPics;
        }
    }
}
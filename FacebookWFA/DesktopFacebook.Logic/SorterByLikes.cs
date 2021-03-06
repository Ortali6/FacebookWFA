﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Logic
{
    internal class SorterByLikes : ICountableSorter
    {
        public bool CompareBySorter(Photo i_Photo1, Photo i_Photo2)
        {
            return i_Photo1.LikedBy.Count > i_Photo2.LikedBy.Count;
        }

        public int GetAmount(Photo i_Photo)
        {
            return i_Photo.LikedBy.Count;
        }
    }
}

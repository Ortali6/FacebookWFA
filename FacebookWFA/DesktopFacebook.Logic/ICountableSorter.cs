using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Logic
{
    internal interface ICountableSorter
    {
        bool CompareBySorter(Photo i_Photo1, Photo i_Photo2);

        int GetAmount(Photo i_Photo);
    }
}

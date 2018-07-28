using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Logic
{
    internal interface ILogin
    {
        User LoggedInUser { get; set; }

        void Login();
    }
}

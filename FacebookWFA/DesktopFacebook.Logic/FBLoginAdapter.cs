using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DesktopFacebook.Logic
{
    internal class FBLoginAdapter : FacebookService, ILogin
    {
        private User m_LoggedInUser;

        User ILogin.LoggedInUser
        {
            get
            {
                return m_LoggedInUser;
            }

            set
            {
            }
        }

        public void Login()
        {
            LoginResult result = FacebookService.Login(
             "1797708417143498",
             "public_profile",
             "user_friends",
             "user_likes",
             "user_tagged_places",
             "publish_actions",
             "user_events",
             "user_posts",
             "user_photos");

            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
            }
            else
            {
                NullReferenceException nullException = new NullReferenceException(result.ErrorMessage);
                throw nullException;
            }
        }
    }
}

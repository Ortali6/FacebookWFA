using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFacebook.Logic
{
    internal static class SorterFactory
    {
        private const string k_SorterByLikes = "Likes";
        private const string k_SorterByComments = "Comments";

        public static ICountableSorter Create(string i_sorter)
        {
            ICountableSorter sorter = null;
            if (i_sorter == k_SorterByLikes)
            {
                sorter = new SorterByLikes();
            }

            if (i_sorter == k_SorterByComments)
            {
                sorter = new SorterByComments();
            }

            return sorter;
        }
    }
}

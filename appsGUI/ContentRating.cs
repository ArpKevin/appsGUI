using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsGUI
{
    public class ContentRating
    {
        public ContentRating(int contentRatingID, string contentRatingName)
        {
            ContentRatingID = contentRatingID;
            ContentRatingName = contentRatingName;
        }

        public int ContentRatingID { get; set; }
        public string ContentRatingName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsGUI
{
    public class Category
    {
        public Category(int categoryID, string categoryName)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}

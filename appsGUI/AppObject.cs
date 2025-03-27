using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsGUI
{
    public class AppObject

    {
        public AppObject(string appName, Category category, ContentRating contentRating, double rating, int reviews, string currentVer, string updateYear, string updateMonth, int id)
        {
            AppName = appName;
            Category = category;
            ContentRating = contentRating;
            Rating = rating;
            Reviews = reviews;
            CurrentVer = currentVer;
            UpdateYear = updateYear;
            UpdateMonth = updateMonth;
            Id = id;
        }

        public string AppName { get; set; }
        public Category Category { get; set; }
        public ContentRating ContentRating { get; set; }
        public double Rating { get; set; }
        public int Reviews { get; set; }
        public string CurrentVer { get; set; }
        public string UpdateYear { get; set; }
        public string UpdateMonth { get; set; }
        public int Id { get; set; }

        public static List<AppObject> LoadFromCsv(string path)
        {
            List<AppObject> apps = new List<AppObject>();


            int i = 0;
            foreach (var item in File.ReadAllLines(path).Skip(1))
            {
                var x = item.Split(";");

                apps.Add(new AppObject(
                    x[0],
                    new Category(int.Parse(x[1]), x[2]),
                    new ContentRating(int.Parse(x[3]), x[4]),
                    double.Parse(x[5].Replace(".", ",")),
                    int.Parse(x[6]),
                    x[7],
                    x[8],
                    x[9],
                    i
                    ));
                i++;
            }


            return apps;
        }

        public override string ToString()
        {
            return $"{Id} {AppName} {getRating(Rating)}";
        }
        public string getRating(double rating)
        {
            if (rating == -1) return "-";

            var stars = Math.Round(rating, 0);
            string starString = "";
            for (int i = 0; i < stars; i++)
            {
                starString += "*";
            }

            return starString;
        }
    }
}

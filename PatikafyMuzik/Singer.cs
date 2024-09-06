using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikafyMuzik
{
    internal class Singer
    {
        public string FullName { get; set; }  // Property
        public List<string> Genre { get; set; }
        public int ReleaseYear { get; set; }

        public int Sales { get; set; }

        public Singer(string name,List<string> genre,int year,int sales) // Constructor
        {
            FullName = name;
            Genre = genre;
            ReleaseYear = year;
            Sales = sales;
        }
    }
}

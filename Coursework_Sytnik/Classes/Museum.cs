using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework_Sytnik.Classes;


namespace Coursework_Sytnik.Classes
{
    public class Museum : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double CoordinateX { get; set; }
        public double CoordinateY { get; set; }
        public List<int> PaintingIds { get; set; } = new List<int>(); 

    }
}

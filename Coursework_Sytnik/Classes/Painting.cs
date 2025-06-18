using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework_Sytnik.Classes;


namespace Coursework_Sytnik.Classes
{
    public class Painting : BaseEntity
    {
        public string Title { get; set; }
        public int CreationYear { get; set; } 
        public string Genre { get; set; }
        public int? ArtistId { get; set; }
        public int? MuseumId { get; set; }

        public override string ToString()
        {
            return $"{Title} ({CreationYear})";
        }
        public int? CollectionEventId { get; set; } 

    }
}

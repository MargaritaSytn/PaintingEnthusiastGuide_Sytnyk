using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik.Classes
{
    public class CollectionEvent : BaseEntity 
    {
        public string Name { get; set; } 
        public DateTime? EventDate { get; set; } 
        public bool IsAuction { get; set; }

        public List<PaintingForSale> PaintingsForSale { get; set; } = new List<PaintingForSale>();

        public string EventTypeDisplay
        {
            get
            {
                return IsAuction ? "Аукціон" : "Комісійний магазин"; 
            }
        }
    }

    public class PaintingForSale
    {
        public int PaintingId { get; set; } 
        public decimal Price { get; set; } 
    }
}

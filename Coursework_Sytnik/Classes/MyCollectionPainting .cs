using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_Sytnik.Classes
{
    public class MyCollectionPainting : BaseEntity
    {
        public int PaintingId { get; set; }
        public decimal PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string SourceEventName { get; set; } 

    }
}
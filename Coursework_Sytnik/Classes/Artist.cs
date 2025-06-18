using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coursework_Sytnik.Classes;

namespace Coursework_Sytnik.Classes
{
    public class Artist : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string YearsOfLife { get; set; } 
        public string Country { get; set; }
        public string Biography { get; set; }
        public List<string> Styles { get; set; } = new List<string>(); 

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({YearsOfLife})";
        }
        public string StylesDisplay
        {
            get
            {

                return Styles != null && Styles.Any() ? string.Join(", ", Styles) : "";
            }
        }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}

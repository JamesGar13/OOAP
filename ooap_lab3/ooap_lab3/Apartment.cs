using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab3
{
    public class Apartment : House
    {
        public List<string> ApartmentOwners { get; set; }

        public Apartment(double area, int floors, string address, List<string> owners)
        {
            Area = area;
            Floors = floors;
            Address = address;
            ApartmentOwners = new List<string>(owners);
        }

        public override House Clone()
        {
            return new Apartment(this.Area, this.Floors, this.Address, new List<string>(this.ApartmentOwners));
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Apartment Building: Area={Area}, Floors={Floors}, Address={Address}");
            Console.WriteLine("Owners:");
            foreach (var owner in ApartmentOwners)
            {
                Console.WriteLine($" - {owner}");
            }
        }
    }
}

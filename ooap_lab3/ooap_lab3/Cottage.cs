using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab3
{
    public class Cottage : House
    {
        public string Owner { get; set; }

        public Cottage(double area, int floors, string address, string owner)
        {
            Area = area;
            Floors = floors;
            Address = address;
            Owner = owner;
        }

        public override House Clone()
        {
            return new Cottage(this.Area, this.Floors, this.Address, this.Owner);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Cottage Building: Area={Area}, Floors={Floors}, Address={Address}, Owner={Owner}");
        }
    }
}

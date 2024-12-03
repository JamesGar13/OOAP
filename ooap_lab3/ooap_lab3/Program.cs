using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<House> houses = new List<House>();

            Apartment apartment = new Apartment(300.0, 2, "221b Baker Street", new List<string> 
            { "Sherlock Holmes", "John Watson" });
            Cottage cottage = new Cottage(200.0, 1, "4 Privet Drive", "Harry Potter");

            houses.Add(apartment);
            houses.Add(cottage);

            Apartment clonedApartment = (Apartment)apartment.Clone();
            clonedApartment.Address = "Changed Address";
            clonedApartment.ApartmentOwners.Add("Rig");
            houses.Add(clonedApartment);

            Console.WriteLine("All Houses:");
            foreach (var house in houses)
            {
                house.DisplayInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Editing house information...");
            if (houses[0] is Apartment editedApartment)
            {
                editedApartment.Address = "Updated Address";
                editedApartment.ApartmentOwners[0] = "Anonymous";
            }

            Console.WriteLine("\nUpdated Houses:");
            foreach (var house in houses)
            {
                house.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}

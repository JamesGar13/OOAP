using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            SkiMuneris snowboard1 = new SkiMuneris("Burton", 101, 42, "Left");
            SkiMuneris snowboard2 = new SkiMuneris("Salomon", 102, 44, "Right");

            Console.WriteLine(snowboard1);
            Console.WriteLine(snowboard2);

            Console.WriteLine();

            Rental basicRental = new SnowboardRental(new BasicRentalService());
            basicRental.AddSnowboard(2);
            Console.WriteLine($"Total price for basic rental: {basicRental.GetTotalPrice()}");

            Console.WriteLine();

            Rental premiumRental = new SnowboardRental(new PremiumRentalService());
            premiumRental.AddSnowboard(3);
            Console.WriteLine($"Total price for premium rental: {premiumRental.GetTotalPrice()}");
        }
    }
}

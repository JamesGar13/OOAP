using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab4
{
    interface IRentalService
    {
        decimal GetPricePerUnit();
        decimal GetSetupPrice();
    }
    abstract class Rental
    {
        protected IRentalService rentalService;

        protected Rental(IRentalService rentalService)
        {
            this.rentalService = rentalService;
        }

        public abstract void AddSnowboard(int count);
        public abstract decimal GetTotalPrice();
    }


    class BasicRentalService : IRentalService
    {
        public decimal GetPricePerUnit()
        {
            return 50m;
        }

        public decimal GetSetupPrice()
        {
            return 20m;
        }
    }
    class PremiumRentalService : IRentalService
    {
        public decimal GetPricePerUnit()
        {
            return 100m;
        }

        public decimal GetSetupPrice()
        {
            return 50m;
        }
    }
    class SnowboardRental : Rental
    {
        private int snowboardCount;

        public SnowboardRental(IRentalService rentalService) : base(rentalService)
        {
            snowboardCount = 0;
        }

        public override void AddSnowboard(int count)
        {
            snowboardCount += count;
            Console.WriteLine($"Added {count} snowboard(s). Total: {snowboardCount}");
        }

        public override decimal GetTotalPrice()
        {
            decimal unitPrice = rentalService.GetPricePerUnit();
            decimal setupPrice = rentalService.GetSetupPrice();
            decimal totalPrice = snowboardCount * unitPrice + setupPrice;
            return totalPrice;
        }
    }

}

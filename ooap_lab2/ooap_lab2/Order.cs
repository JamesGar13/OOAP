using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    class Order
    {
        private List<Facade> _facades = new List<Facade>();

        public void AddFacade(Facade facade)
        {
            _facades.Add(facade);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var facade in _facades)
            {
                total += facade.GetArea() * facade.GetPrice();
            }
            return total;
        }

        public void PrintOrderDetails()
        {
            foreach (var facade in _facades)
            {
                Console.WriteLine(facade.GetDescription());
            }
        }
    }
}

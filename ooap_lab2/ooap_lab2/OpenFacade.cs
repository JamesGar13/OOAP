using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    internal class OpenFacade : Facade
    {
        public override double GetPrice()
        {
            return 12;
        }

        public override string GetDescription()
        {
            return $"Вітрина ({Width}м x {Height}м)";
        }
    }
}

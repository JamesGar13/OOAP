using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    internal class SolidFacade : Facade
    {
        public override double GetPrice()
        {
            return 100;
        }

        public override string GetDescription()
        {
            return $"Суцільний фасад ({Width}м x {Height}м)";
        }
    }
}

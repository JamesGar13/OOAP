using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    class PaintedFacadeFactory : IFacadeFactory
    {
        public Facade CreateSolidFacade(double width, double height)
        {
            return new SolidFacade { Width = width, Height = height };
        }

        public Facade CreateOpenFacade(double width, double height)
        {
            return new OpenFacade { Width = width, Height = height };
        }
    }
}

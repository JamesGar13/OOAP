using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    interface IFacadeFactory
    {
        Facade CreateSolidFacade(double width, double height);
        Facade CreateOpenFacade(double width, double height);
    }
}

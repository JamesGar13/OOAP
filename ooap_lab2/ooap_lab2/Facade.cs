using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    abstract class Facade
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public abstract double GetPrice();

        public double GetArea()
        {
            return Width * Height;
        }

        public abstract string GetDescription();
    }
}

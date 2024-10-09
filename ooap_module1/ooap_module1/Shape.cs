using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_module1
{
    abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Об’єкт створено");
        }

        public abstract double CalculateArea();

       
        public override string ToString()
        {
            return $"Площа фігури: {CalculateArea()}";
        }
    }
}

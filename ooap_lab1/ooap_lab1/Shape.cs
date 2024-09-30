using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab1
{
    abstract class Shape
    {
        public Shape()
        {
            Console.WriteLine("Об’єкт створено");
        }

        public abstract double CalculateArea();

        public void PrintArea()
        {
            Console.WriteLine($"Площа фігури: {CalculateArea()}");
        }
    }
}

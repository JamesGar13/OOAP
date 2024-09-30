using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Shape square = new Square(4);
            Shape rectangle = new Rectangle(4, 6);
            Shape circle = new Circle(5);

            square.PrintArea();
            rectangle.PrintArea();
            circle.PrintArea();
        }
    }
}

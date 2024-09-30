using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            IFacadeFactory facadeFactory = null;
            Console.WriteLine("Оберіть тип матеріалу (1 - Плівкові, 2 - Фарбовані, 3 - Пластикові): ");
            string materialChoice = Console.ReadLine();

            switch (materialChoice)
            {
                case "1":
                    facadeFactory = new LaminaFacadeFactory();
                    break;
                case "2":
                    facadeFactory = new PaintedFacadeFactory();
                    break;
                case "3":
                    facadeFactory = new PlasticFacadeFactory();
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    return;
            }

            Order order = new Order();

            Console.WriteLine("Додайте фасади (суцільний - S, вітрина - W). Введіть Q для завершення.");
            while (true)
            {
                Console.WriteLine("Оберіть тип фасаду (S або W): ");
                string facadeType = Console.ReadLine();

                if (facadeType.ToUpper() == "Q")
                    break;

                Console.WriteLine("Введіть ширину фасаду в метрах: ");
                double width = double.Parse(Console.ReadLine());

                Console.WriteLine("Введіть висоту фасаду в метрах: ");
                double height = double.Parse(Console.ReadLine());

                Facade facade = null;

                if (facadeType.ToUpper() == "S")
                {
                    facade = facadeFactory.CreateSolidFacade(width, height);
                }
                else if (facadeType.ToUpper() == "W")
                {
                    facade = facadeFactory.CreateOpenFacade(width, height);
                }
                else
                {
                    Console.WriteLine("Невірний тип фасаду!");
                    continue;
                }

                order.AddFacade(facade);
            }

            Console.WriteLine("Деталі замовлення:");
            order.PrintOrderDetails();

            double totalPrice = order.GetTotalPrice();
            Console.WriteLine($"Загальна вартість замовлення: {totalPrice} грн.");
        }
    }
}
    
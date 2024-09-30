using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            
            Console.WriteLine("1. Проста комплектація");
            Console.WriteLine("2. Базова комплектація");
            Console.WriteLine("3. Преміум комплектація");
            Console.WriteLine("4. Повна комплектація");

            while (true)
            {
                Console.WriteLine("\nОберіть комплектацію автомобіля:");
                string choice = Console.ReadLine();

                ICarBuilder builder = null;

                switch (choice)
                {
                    case "1":
                        builder = new CommonConfigBuilder();
                        break;
                    case "2":
                        builder = new BasicConfigBuilder();
                        break;
                    case "3":
                        builder = new PremiumConfigBuilder();
                        break;
                    case "4":
                        builder = new FullConfigBuilder();
                        break;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        return;
                }

                CarDirector director = new CarDirector(builder);
                director.Construct();
                Car car = builder.GetCar();
                car.ShowInfo();
            }
            
        }
    }
}

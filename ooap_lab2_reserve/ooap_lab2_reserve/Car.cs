using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class Car
    {
        public string Model { get; set; }
        public string EngineType { get; set; }
        public double EngineCapacity { get; set; } 
        public bool HasABS { get; set; }
        public bool HasESP { get; set; }
        public int Airbags { get; set; }
        public bool HasOnboardComputer { get; set; }
        public string AirConditioningType { get; set; }
        public string InteriorMaterial { get; set; }
        public double Price { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Тип двигуна: {EngineType}");
            Console.WriteLine($"Об'єм двигуна: {EngineCapacity} л");
            Console.WriteLine($"Антиблокувальна система гальм (ABS): {(HasABS ? "Так" : "Ні")}");
            Console.WriteLine($"Система стабілізації (ESP): {(HasESP ? "Так" : "Ні")}");
            Console.WriteLine($"Кількість подушок безпеки: {Airbags}");
            Console.WriteLine($"Бортовий комп'ютер: {(HasOnboardComputer ? "Так" : "Ні")}");
            Console.WriteLine($"Кліматична система: {AirConditioningType}");
            Console.WriteLine($"Матеріал обшивки: {InteriorMaterial}");
            Console.WriteLine($"Ціна: {Price} грн");
        }
    }
}

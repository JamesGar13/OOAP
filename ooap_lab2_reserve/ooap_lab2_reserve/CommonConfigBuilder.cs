using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class CommonConfigBuilder : CarBuilder
    {
        public override void SetModel()
        {
            car.Model = "Звичайна комплектація";
        }

        public override void SetEngineType()
        {
            car.EngineType = "Бензиновий";
        }

        public override void SetEngineCapacity()
        {
            car.EngineCapacity = 1.8;
        }

        public override void SetABS()
        {
            car.HasABS = true;
        }

        public override void SetESP()
        {
            car.HasESP = false;
        }

        public override void SetAirbags()
        {
            car.Airbags = 2;
        }

        public override void SetOnboardComputer()
        {
            car.HasOnboardComputer = true;
        }

        public override void SetAirConditioning()
        {
            car.AirConditioningType = "Кондиціонер";
        }

        public override void SetInteriorMaterial()
        {
            car.InteriorMaterial = "Тканина";
        }

        public override void SetPrice()
        {
            car.Price = 250000;
        }
    }
}

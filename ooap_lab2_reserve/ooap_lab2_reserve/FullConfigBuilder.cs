using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class FullConfigBuilder : CarBuilder
    {
        public override void SetModel()
        {
            car.Model = "Повна комплектація";
        }

        public override void SetEngineType()
        {
            car.EngineType = "Дизельний";
        }

        public override void SetEngineCapacity()
        {
            car.EngineCapacity = 2.0;
        }

        public override void SetABS()
        {
            car.HasABS = true;
        }

        public override void SetESP()
        {
            car.HasESP = true;
        }

        public override void SetAirbags()
        {
            car.Airbags = 6;
        }

        public override void SetOnboardComputer()
        {
            car.HasOnboardComputer = true;
        }

        public override void SetAirConditioning()
        {
            car.AirConditioningType = "Клімат-контроль";
        }

        public override void SetInteriorMaterial()
        {
            car.InteriorMaterial = "Шкіра";
        }

        public override void SetPrice()
        {
            car.Price = 500000;
        }
    }
}

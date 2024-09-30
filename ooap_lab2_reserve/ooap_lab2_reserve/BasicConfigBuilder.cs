using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class BasicConfigBuilder : CarBuilder
    {
        public override void SetModel()
        {
            car.Model = "Базова комплектація";
        }

        public override void SetEngineType()
        {
            car.EngineType = "Бензиновий";
        }

        public override void SetEngineCapacity()
        {
            car.EngineCapacity = 1.6;
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
            car.HasOnboardComputer = false;
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
            car.Price = 300000;
        }
    }
}

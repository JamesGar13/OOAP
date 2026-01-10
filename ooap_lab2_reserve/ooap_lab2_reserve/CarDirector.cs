using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class CarDirector
    {
        private ICarBuilder builder;

        public CarDirector(ICarBuilder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.SetModel();
            builder.SetEngineType();
            builder.SetEngineCapacity();
            builder.SetABS();
            builder.SetESP();
            builder.SetAirbags();
            builder.SetOnboardComputer();
            builder.SetAirConditioning();
            builder.SetInteriorMaterial();
            builder.SetPrice();
        }
    }

}

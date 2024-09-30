using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    interface ICarBuilder
    {
        void SetModel();
        void SetEngineType();
        void SetEngineCapacity();
        void SetABS();
        void SetESP();
        void SetAirbags();
        void SetOnboardComputer();
        void SetAirConditioning();
        void SetInteriorMaterial();
        void SetPrice();

        Car GetCar();
    }

}

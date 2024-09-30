using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab2_reserve
{
    class CarBuilder : ICarBuilder
    {
        protected Car car;

        public CarBuilder()
        {
            car = new Car();
        }

        public virtual void SetModel() { }
        public virtual void SetEngineType() { }
        public virtual void SetEngineCapacity() { }
        public virtual void SetABS() { }
        public virtual void SetESP() { }
        public virtual void SetAirbags() { }
        public virtual void SetOnboardComputer() { }
        public virtual void SetAirConditioning() { }
        public virtual void SetInteriorMaterial() { }
        public virtual void SetPrice() { }

        public Car GetCar()
        {
            return car;
        }
    }
}

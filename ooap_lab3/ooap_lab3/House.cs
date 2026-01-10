using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab3
{
    public abstract class House
    {
        public double Area { get; set; }
        public int Floors { get; set; }
        public string Address { get; set; }

        public abstract House Clone();
        public abstract void DisplayInfo();
    }
}

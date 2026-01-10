using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab4_reserve
{
    interface Phone
    {
        void MakeCall();
    }
    class MobilePhone : Phone
    {
        public void MakeCall()
        {
            Console.WriteLine("Making a regular voice call...");
        }
    }
}

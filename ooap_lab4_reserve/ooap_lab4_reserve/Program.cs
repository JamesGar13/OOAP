using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab4_reserve
{

        class Program
        {
            static void Main(string[] args)
            {
                Phone regularPhone = new MobilePhone();
                regularPhone.MakeCall();

                Console.WriteLine();

                VideoCamera camera = new VideoCamera();
                Phone videoCall = new VideoCallAdapter(camera);
                videoCall.MakeCall();
            }
        }
}

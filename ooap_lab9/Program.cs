using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order();

            order.PrintStatus();
            order.NextState();
            order.CancelState();
            order.PrintStatus();
            order.NextState();  
            order.CancelState();
            order.PrintStatus();
            order.NextState();
            Console.WriteLine();

            var order2 = new Order();

            order2.PrintStatus();
            order2.CancelState();
            order2.NextState();
            order2.CancelState();
            order2.PrintStatus();
            Console.WriteLine();
        }

    }

    public class Order
    {
        public IOrderState _state;

        public Order() 
        
        {
            _state = new NewOrder();
        }

        public void SetState(IOrderState state) 
        {
            _state = state;
        }
        public void NextState() 
        {
            _state.Next(this);
        }
        public void CancelState() 
        {
        _state.Cancel(this);
        }
        public void PrintStatus()
        {
            _state.Status();
        }


    }

}

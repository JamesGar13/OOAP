using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab9
{
    public interface IOrderState
    {
        void Next(Order order);
        void Cancel(Order order);
        void Status();
    }

    public class NewOrder : IOrderState
    {

        public void Next(Order order)
        {
            Console.WriteLine("Order sent");
            order.SetState(new Shipped());
        }
        public void Cancel(Order order) 
        {
            Console.WriteLine("Order cancelled");
            order.SetState(new Cancelled());
        }
        public void Status()
        {
            Console.WriteLine("Status: new order");
        }

    }
    public class Shipped : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Order is shipping");
            order.SetState(new Invoiced());
        }
        public void Cancel(Order order)
        {
            Console.WriteLine("Cannot cancel - on the way");
        }
        public void Status()
        {
            Console.WriteLine("Status: sent");
        }

    }

    public class Invoiced : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Order paid");
        }
        public void Cancel(Order order)
        {
            Console.WriteLine("Cannot cancel - already paid");
        }
        public void Status()
        {
            Console.WriteLine("Status: paid");
        }

    }
    public class Cancelled : IOrderState
    {
        public void Next(Order order)
        {
            Console.WriteLine("Request impossible: order cancelled");
        }
        public void Cancel(Order order)
        {
            Console.WriteLine("Successfully cancelled");
        }
        public void Status()
        {
            Console.WriteLine("Status: Cancelled");
        }

    }

}

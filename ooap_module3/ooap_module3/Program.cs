using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_module3
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    #region func
    public class AddOrderCommand : ICommand
    {
        private FastFoodService _fastFoodService;
        private Order _order;

        public AddOrderCommand(FastFoodService fastFoodService, Order order)
        {
            _fastFoodService = fastFoodService;
            _order = order;
        }

        public void Execute()
        {
            _fastFoodService.AddOrder(_order);
        }

        public void Undo()
        {
            _fastFoodService.RemoveOrder(_order);
        }
    }

    public class RemoveOrderCommand : ICommand
    {
        private FastFoodService _fastFoodService;
        private Order _order;

        public RemoveOrderCommand(FastFoodService fastFoodService, Order order)
        {
            _fastFoodService = fastFoodService;
            _order = order;
        }

        public void Execute()
        {
            _fastFoodService.RemoveOrder(_order);
        }

        public void Undo()
        {
            _fastFoodService.AddOrder(_order);
        }
    }
    #endregion
    public class FastFoodService
    {
        private List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            _orders.Add(order);
            Console.WriteLine($"Order Added: {order.Name}, Price: {order.Price}");
        }

        public void RemoveOrder(Order order)
        {
            _orders.Remove(order);
            Console.WriteLine($"Order Removed: {order.Name}");
        }

        public void ShowOrders()
        {
            Console.WriteLine("Current Orders:");
            foreach (var order in _orders)
            {
                Console.WriteLine($"{order.Name} - {order.Price}");
            }
        }
    }

    public class Order
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Order(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class OrderInvoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }

        public void UndoCommand()
        {
            _command.Undo();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
                FastFoodService fastFoodService = new FastFoodService();

                Order burgerOrder = new Order("Burger", 5.99);
                Order friesOrder = new Order("Fries", 2.99);

                ICommand addBurgerOrder = new AddOrderCommand(fastFoodService, burgerOrder);
                ICommand addFriesOrder = new AddOrderCommand(fastFoodService, friesOrder);
                ICommand removeBurgerOrder = new RemoveOrderCommand(fastFoodService, burgerOrder);

                OrderInvoker invoker = new OrderInvoker();

                invoker.SetCommand(addBurgerOrder);
                invoker.ExecuteCommand();
                invoker.SetCommand(addFriesOrder);
                invoker.ExecuteCommand();

                fastFoodService.ShowOrders();

                invoker.SetCommand(removeBurgerOrder);
                invoker.ExecuteCommand();

                fastFoodService.ShowOrders();

                invoker.UndoCommand();
                fastFoodService.ShowOrders();
            
        }
    }
}

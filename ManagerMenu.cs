using System;

namespace WMS
{
    internal class ManagerMenu : MainMenu
    {
        private readonly Manager _manager;
        private readonly Warehouse _warehouse;

        public ManagerMenu(Manager manager, Warehouse warehouse)
        {
            _manager = manager;
            _warehouse = warehouse;
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Manager menu:");
            Console.WriteLine("1 - Make report");
            Console.WriteLine("2 - Show profit statistics");
            Console.WriteLine("3 - Change product price");
            Console.WriteLine("0 - Exit");
        }

        public override void ExecuteOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    _manager.MakeReport();
                    break;
                case 2:
                    _manager.ShowProfitStatistics();
                    break;
                case 3:
                    ChangePrice();
                    break;
                default:
                    Console.WriteLine("Unknown operation.");
                    break;
            }
        }

        private void ChangePrice()
        {
            Console.Write("Product name: ");
            var name = Console.ReadLine() ?? string.Empty;
            var product = _warehouse.FindProduct(name);

            if (product == null)
            {
                Console.WriteLine("Product not found.");
                return;
            }

            Console.Write("New price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var newPrice))
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            _manager.ChangePrice(product, newPrice);
        }
    }
}

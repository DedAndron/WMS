using System;

namespace WMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new();
            WorkerList workerList = new();

            Storekeeper storekeeper = new("Ivan", warehouse);
            Manager manager = new("Maria");
            Admin admin = new("Boss", workerList);

            admin.AddWorker(admin);
            admin.AddWorker(storekeeper);
            admin.AddWorker(manager);

            warehouse.LowStockAlert += OnLowStockAlert;
            SeedProducts(warehouse);

            while (true)
            {
                Console.WriteLine("Select user menu:");
                Console.WriteLine("1 - Admin");
                Console.WriteLine("2 - Manager");
                Console.WriteLine("3 - Storekeeper");
                Console.WriteLine("0 - Exit application");
                Console.Write("Choose operation: ");

                if (!int.TryParse(Console.ReadLine(), out var operation))
                {
                    Console.WriteLine("Invalid input.");
                    Console.WriteLine();
                    continue;
                }

                if (operation == 0)
                {
                    Console.WriteLine("Application finished.");
                    break;
                }

                try
                {
                    MainMenu menu = operation switch
                    {
                        1 => new AdminMenu(admin, workerList, warehouse),
                        2 => new ManagerMenu(manager, warehouse),
                        3 => new StorekeeperMenu(storekeeper),
                        _ => null
                    };

                    if (menu == null)
                    {
                        Console.WriteLine("Unknown operation.");
                    }
                    else
                    {
                        menu.Start();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Operation failed: {ex.Message}");
                }

                Console.WriteLine();
            }
        }

        private static void OnLowStockAlert(object? sender, LowStockEventArgs e)
        {
            Console.WriteLine($"[LOW STOCK ALERT] Product '{e.Product.Name}' has only {e.Quantity} item(s) left.");
        }

        private static void SeedProducts(Warehouse warehouse)
        {
            warehouse.Add(new Electronics
            {
                ID = 1,
                Name = "Laptop",
                Price = 1200m,
                Weight = 2.4f,
                Quantity = 10
            });

            warehouse.Add(new Electronics
            {
                ID = 2,
                Name = "Mouse",
                Price = 25m,
                Weight = 0.1f,
                Quantity = 3
            });
        }
    }
}

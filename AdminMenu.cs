using System;
using System.Linq;

namespace WMS
{
    internal class AdminMenu : MainMenu
    {
        private readonly Admin _admin;
        private readonly WorkerList _workerList;
        private readonly Warehouse _warehouse;

        public AdminMenu(Admin admin, WorkerList workerList, Warehouse warehouse)
        {
            _admin = admin;
            _workerList = workerList;
            _warehouse = warehouse;
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Admin menu:");
            Console.WriteLine("1 - Add worker");
            Console.WriteLine("2 - Block worker");
            Console.WriteLine("3 - Change worker role");
            Console.WriteLine("0 - Exit");
        }

        public override void ExecuteOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    AddWorker();
                    break;
                case 2:
                    BlockWorker();
                    break;
                case 3:
                    ChangeWorkerRole();
                    break;
                default:
                    Console.WriteLine("Unknown operation.");
                    break;
            }
        }

        private void AddWorker()
        {
            Console.Write("Worker name: ");
            var name = (Console.ReadLine() ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Worker? worker = CreateWorkerByChoice(name);
            if (worker == null)
            {
                Console.WriteLine("Unknown role.");
                return;
            }

            _admin.AddWorker(worker);
        }

        private Worker? CreateWorkerByChoice(string name)
        {
            Console.WriteLine("Choose worker role:");
            Console.WriteLine("1 - Admin");
            Console.WriteLine("2 - Manager");
            Console.WriteLine("3 - Storekeeper");
            Console.Write("Role number: ");

            if (!int.TryParse(Console.ReadLine(), out var roleChoice))
            {
                return null;
            }

            switch (roleChoice)
            {
                case 1:
                    return new Admin(name, _workerList);
                case 2:
                    return new Manager(name);
                case 3:
                    return new Storekeeper(name, _warehouse);
                default:
                    return null;
            }
        }

        private void BlockWorker()
        {
            Console.Write("Worker name to block: ");
            var name = (Console.ReadLine() ?? string.Empty).Trim();
            _admin.BlockWorker(name);
        }

        private void ChangeWorkerRole()
        {
            Console.Write("Worker name: ");
            var name = (Console.ReadLine() ?? string.Empty).Trim();
            var worker = _workerList.GetAll()
                .FirstOrDefault(w => string.Equals(w.Name, name, StringComparison.OrdinalIgnoreCase));

            if (worker == null)
            {
                Console.WriteLine("Worker not found.");
                return;
            }

            WorkerRole role = ReadWorkerRoleChoice();
            if (role == WorkerRole.None)
            {
                Console.WriteLine("Unknown role.");
                return;
            }

            _admin.ChangePost(worker, role, _warehouse);
            Console.WriteLine("Role has been changed.");
        }

        private static WorkerRole ReadWorkerRoleChoice()
        {
            Console.WriteLine("Choose new worker role:");
            Console.WriteLine("1 - Admin");
            Console.WriteLine("2 - Manager");
            Console.WriteLine("3 - Storekeeper");
            Console.Write("Role number: ");

            if (!int.TryParse(Console.ReadLine(), out var roleChoice))
            {
                return WorkerRole.None;
            }

            return roleChoice switch
            {
                1 => WorkerRole.Admin,
                2 => WorkerRole.Manager,
                3 => WorkerRole.Storekeeper,
                _ => WorkerRole.None
            };
        }
    }
}
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

            Console.Write("Role (admin/manager/storekeeper): ");
            var roleInput = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

            Worker? worker = roleInput switch
            {
                "admin" => new Admin(name, _workerList),
                "manager" => new Manager(name),
                "storekeeper" => new Storekeeper(name, _warehouse),
                _ => null
            };

            if (worker == null)
            {
                Console.WriteLine("Unknown role.");
                return;
            }

            _admin.AddWorker(worker);
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

            Console.Write("New role (admin/manager/storekeeper): ");
            var roleInput = (Console.ReadLine() ?? string.Empty).Trim().ToLowerInvariant();

            var role = roleInput switch
            {
                "admin" => WorkerRole.Admin,
                "manager" => WorkerRole.Manager,
                "storekeeper" => WorkerRole.Storekeeper,
                _ => WorkerRole.None
            };

            if (role == WorkerRole.None)
            {
                Console.WriteLine("Unknown role.");
                return;
            }

            _admin.ChangePost(worker, role, _warehouse);
            Console.WriteLine("Role has been changed.");
        }
    }
}
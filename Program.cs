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

            admin.AddWorker(storekeeper);
            admin.AddWorker(manager);

            admin.BlockWorker("Ivan");
        }
    }
}

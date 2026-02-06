namespace WMS
{
    interface IWorkersControl
    {
        void AddWorker(Worker worker);
        void BlockWorker(string name);
        void ChangePost(Worker worker, WorkerRole newRole, Warehouse warehouse);
    }

    internal class Admin : Worker, IWorkersControl
    {
        private readonly WorkerList _workerList;

        public Admin(string name, WorkerList workerList)
            : base(name)
        {
            _workerList = workerList;
        }

        public void AddWorker(Worker worker)
        {
            _workerList.AddWorker(worker);
            Console.WriteLine($"A new worker has been added.\n{worker.Name}");
        }

        public void BlockWorker(string name)
        {
            _workerList.BlockWorker(name);
            Console.WriteLine($"A worker has been blocked.\n{name}");
        }

        public void ChangePost(Worker worker, WorkerRole newRole, Warehouse warehouse)
        {
            _workerList.ChangePost(worker, newRole, warehouse);
        }
    }
}

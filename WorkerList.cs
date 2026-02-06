using System;
using System.Collections.Generic;
using System.Linq;

namespace WMS
{
    internal class WorkerList
    {
        private readonly List<Worker> _workers = new();

        public void AddWorker(Worker worker)
        {
            ArgumentNullException.ThrowIfNull(worker);

            if (_workers.Any(w => string.Equals(w.Name, worker.Name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"Worker '{worker.Name}' already exists.");

            _workers.Add(worker);
        }

        public bool BlockWorker(string name)
        {
            var worker = _workers.FirstOrDefault(w => string.Equals(w.Name, name, StringComparison.OrdinalIgnoreCase));

            if (worker == null)
                throw new ArgumentNullException(nameof(name), "Worker not found!");

            if (!worker.Active)
                throw new InvalidOperationException("The worker is already blocked!");

            worker.Active = false;
            return true;
        }

        public void ChangePost(Worker oldWorker, Worker newWorker)
        {
            int index = _workers.IndexOf(oldWorker);

            if (index == -1)
                throw new InvalidOperationException("Worker not found!");

            _workers[index] = newWorker;
        }

        public void ChangePost(Worker worker, WorkerRole newRole, Warehouse warehouse)
        {
            Worker newWorker = newRole switch
            {
                WorkerRole.Admin => new Admin(worker.Name, this),
                WorkerRole.Manager => new Manager(worker.Name),
                WorkerRole.Storekeeper => new Storekeeper(worker.Name, warehouse),
                _ => throw new ArgumentException("Unknown worker role", nameof(newRole))
            };

            newWorker.Active = worker.Active;
            ChangePost(worker, newWorker);
        }

        public IReadOnlyList<Worker> GetAll()
        {
            return _workers.AsReadOnly();
        }
    }
}
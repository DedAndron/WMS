using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal class WorkerList
    {
        private List<Worker> _workers = new();

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public bool BlockWorker(string name)
        {
            var worker = _workers.FirstOrDefault(w => w.Name == name);

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

        public IReadOnlyList<Worker> GetAll()
        {
            return _workers.AsReadOnly();
        }
    }

}

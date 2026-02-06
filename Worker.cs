using System;

namespace WMS
{
    internal enum WorkerRole
    {
        None = 0,
        Admin = 1,
        Manager = 2,
        Storekeeper = 3
    }

    internal abstract class Worker
    {
        public string Name { get; set; }
        public bool Active { get; set; } = true;

        protected Worker(string name)
        {
            Name = name;
        }
    }
}

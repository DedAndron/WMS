using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal class WorkerList
    {
        public List<Worker> workers;
        public WorkerList(Worker worker)
        {
            workers = new List<Worker>();
        }
    }
}

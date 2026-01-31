using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    interface IWorkersControl
    {

    }
    internal class Admin : Worker, IWorkersControl
    {
        private WorkerList _workerList;
    }
}

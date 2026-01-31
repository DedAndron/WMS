using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
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

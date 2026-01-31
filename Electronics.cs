using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal class Electronics : Product
    {
        public int WarrantyPeriod { get; set; }
        public int Voltage {  get; set; }
        public override void GetStorageRequirements()
        {
            throw new NotImplementedException();
        }
    }
}

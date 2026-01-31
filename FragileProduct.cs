using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal class FragileProduct : Product
    {
        public int MaxStakingHeight { get; set; }
        public override void GetStorageRequirements()
        {
            throw new NotImplementedException();
        }
    }
}

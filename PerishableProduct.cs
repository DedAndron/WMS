using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal class PerishableProduct : Product
    {
        public DateTime ExpiryDate { get; set; }
        public PerishableProduct (DateTime ExpiryDate)
        {
            this.ExpiryDate = ExpiryDate;
        }

        public override void GetStorageRequirements()
        {
            throw new NotImplementedException();
        }
    }
}

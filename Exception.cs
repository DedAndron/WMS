using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal class InvalidWeightException : ApplicationException
    {
        public InvalidWeightException(string message) : base(message) { }
    }
    internal class InvalidExpiryDateException : ApplicationException
    {
        public InvalidExpiryDateException(string message) : base(message) { }
    }
}

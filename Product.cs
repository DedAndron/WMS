using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    internal abstract class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight {  get; set; }
        public int Quantity { get; set; }

        public abstract void GetStorageRequirements();
        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Quantity: {Quantity}";
        }
    }
}

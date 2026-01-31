using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    interface IInvertoryControl
    {
        void AddItem(Product p);
        bool RemoveItem(string id);
        Product FindProduct(string name);

        List<Product> SortByType(Type productType);
        List<Product> SortByName();
        List<Product> SortByPrice();
        List<Product> SortByWeight();
    }
    internal class Storekeeper : Worker, IInvertoryControl
    {
        private Warehouse _warehouse;

        public Storekeeper(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void AddItem(Product product)
        {
            _warehouse.Add(product);
        }

        public bool RemoveItem(string id)
        {
            return _warehouse.RemoveById(id);
        }

        public Product FindProduct(string name)
        {
            var product = _warehouse.FindByName(name);
            if (product == null)
                throw new InvalidOperationException("Product not found.");

            return product;
        }
        public List<Product> SortByType(Type productType)
        {
            return _warehouse.GetAll()
                .OrderBy(p => p.GetType() == productType ? 0 : 1)
                .ToList();
        }
        public List<Product> SortByName()
        {
            return _warehouse.GetAll()
                .OrderBy(p => p.Name)
                .ToList();
        }

        public List<Product> SortByPrice()
        {
            return _warehouse.GetAll()
                .OrderBy(p => p.Price)
                .ToList();
        }

        public List<Product> SortByWeight()
        {
            return _warehouse.GetAll()
                .OrderBy(p => p.Weight)
                .ToList();
        }
    }
}

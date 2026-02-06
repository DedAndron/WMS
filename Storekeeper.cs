using System;
using System.Collections.Generic;
using System.Linq;

namespace WMS
{
    interface IInventoryControl
    {
        void AddItem(Product product);
        bool RemoveItem(int id);
        Product? FindProduct(string name);
        void MakeInventory();
        List<Product> SortByType(Type productType);
        List<Product> SortByName();
        List<Product> SortByPrice();
        List<Product> SortByWeight();
    }

    internal class Storekeeper : Worker, IInventoryControl
    {
        private readonly Warehouse _warehouse;

        public Storekeeper(string name, Warehouse warehouse)
            : base(name)
        {
            _warehouse = warehouse;
        }

        public void AddItem(Product product)
        {
            _warehouse.Add(product);
        }

        public bool RemoveItem(int id)
        {
            return _warehouse.RemoveById(id);
        }

        public Product? FindProduct(string name)
        {
            return _warehouse.FindProduct(name);
        }

        public void MakeInventory()
        {
            Console.WriteLine("Inventory list:");
            foreach (var product in _warehouse.GetAll())
            {
                Console.WriteLine(product);
            }
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

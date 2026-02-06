using System;
using System.Collections.Generic;
using System.Linq;

namespace WMS
{
    internal sealed class LowStockEventArgs : EventArgs
    {
        public Product Product { get; }
        public int Quantity { get; }

        public LowStockEventArgs(Product product)
        {
            Product = product;
            Quantity = product.Quantity;
        }
    }

    internal class Warehouse
    {
        private readonly List<Product> _products = new();
        public event EventHandler<LowStockEventArgs>? LowStockAlert;

        public void Add(Product product)
        {
            ArgumentNullException.ThrowIfNull(product);

            if (_products.Any(p => p.ID == product.ID))
                throw new InvalidOperationException($"Product with ID {product.ID} already exists.");

            _products.Add(product);
            CheckLowStock(product);
        }

        public bool RemoveById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }

        public bool DecreaseQuantity(int id, int amount)
        {
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount should be greater than zero.");

            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product == null || product.Quantity < amount)
                return false;

            product.Quantity -= amount;
            CheckLowStock(product);
            return true;
        }

        public bool SetQuantity(int id, int quantity)
        {
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity cannot be negative.");

            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product == null)
                return false;

            product.Quantity = quantity;
            CheckLowStock(product);
            return true;
        }

        public Product? FindProduct(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Invalid name", nameof(name));

            return _products.FirstOrDefault(p =>
                string.Equals(p.Name, name.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        public IReadOnlyList<Product> GetAll()
        {
            return _products.AsReadOnly();
        }

        private void CheckLowStock(Product product)
        {
            if (product.Quantity < 5)
            {
                LowStockAlert?.Invoke(this, new LowStockEventArgs(product));
            }
        }
    }
}
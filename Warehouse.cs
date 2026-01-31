using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{

    internal class Warehouse
{
    private List<Product> _products = new();

    public void Add(Product product)
    {
        _products.Add(product);
    }

    public bool RemoveById(int id)
    {
        var product = _products.FirstOrDefault(p => p.ID == id);
        if (product == null) return false;

        _products.Remove(product);
        return true;
    }

    public Product FindProduct(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Invalid name", nameof(name));

        return _products.FirstOrDefault(p => p.Name == name);
    }

    public IReadOnlyList<Product> GetAll()
    {
        return _products.AsReadOnly();
    }
}

}

using System;
using System.Collections.Generic;

namespace WMS
{
    internal class StorekeeperMenu : MainMenu
    {
        private readonly Storekeeper _storekeeper;

        public StorekeeperMenu(Storekeeper storekeeper)
        {
            _storekeeper = storekeeper;
        }

        public override void ShowMenu()
        {
            Console.WriteLine("Storekeeper menu:");
            Console.WriteLine("1 - Add product");
            Console.WriteLine("2 - Remove product by ID");
            Console.WriteLine("3 - Find product by name");
            Console.WriteLine("4 - Show inventory");
            Console.WriteLine("5 - Sort by name");
            Console.WriteLine("6 - Sort by price");
            Console.WriteLine("7 - Sort by weight");
            Console.WriteLine("0 - Exit");
        }

        public override void ExecuteOperation(int operation)
        {
            switch (operation)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    RemoveProduct();
                    break;
                case 3:
                    FindProduct();
                    break;
                case 4:
                    _storekeeper.MakeInventory();
                    break;
                case 5:
                    PrintProducts(_storekeeper.SortByName());
                    break;
                case 6:
                    PrintProducts(_storekeeper.SortByPrice());
                    break;
                case 7:
                    PrintProducts(_storekeeper.SortByWeight());
                    break;
                default:
                    Console.WriteLine("Unknown operation.");
                    break;
            }
        }

        private void AddProduct()
        {
            Product? product = CreateProductByType();
            if (product == null)
            {
                Console.WriteLine("Unknown product type.");
                return;
            }

            Console.Write("ID: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            Console.Write("Name: ");
            var name = Console.ReadLine() ?? string.Empty;

            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price.");
                return;
            }

            Console.Write("Weight: ");
            if (!float.TryParse(Console.ReadLine(), out var weight))
            {
                Console.WriteLine("Invalid weight.");
                return;
            }

            Console.Write("Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            product.ID = id;
            product.Name = name;
            product.Price = price;
            product.Weight = weight;
            product.Quantity = quantity;

            FillSpecificFields(product);

            _storekeeper.AddItem(product);
            Console.WriteLine($"Product added with type: {product.GetType().Name}.");
        }

        private static Product? CreateProductByType()
        {
            Console.WriteLine("Choose product type:");
            Console.WriteLine("1 - Electronics");
            Console.WriteLine("2 - FragileProduct");
            Console.WriteLine("3 - PerishableProduct");
            Console.Write("Type number: ");

            if (!int.TryParse(Console.ReadLine(), out var typeChoice))
            {
                return null;
            }

            switch (typeChoice)
            {
                case 1:
                    return new Electronics();
                case 2:
                    return new FragileProduct();
                case 3:
                    return new PerishableProduct();
                default:
                    return null;
            }
        }
        private static void FillSpecificFields(Product product)
        {
            switch (product)
            {
                case Electronics electronics:
                    Console.Write("Warranty period (months): ");
                    if (int.TryParse(Console.ReadLine(), out var warrantyPeriod))
                    {
                        electronics.WarrantyPeriod = warrantyPeriod;
                    }

                    Console.Write("Voltage: ");
                    if (int.TryParse(Console.ReadLine(), out var voltage))
                    {
                        electronics.Voltage = voltage;
                    }
                    break;

                case FragileProduct fragileProduct:
                    Console.Write("Max stacking height: ");
                    if (int.TryParse(Console.ReadLine(), out var maxHeight))
                    {
                        fragileProduct.MaxStakingHeight = maxHeight;
                    }
                    break;

                case PerishableProduct perishableProduct:
                    Console.Write("Expiry date (yyyy-MM-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out var expiryDate))
                    {
                        perishableProduct.ExpiryDate = expiryDate;
                    }
                    break;
            }
        }
        private void RemoveProduct()
        {
            Console.Write("Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out var id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var removed = _storekeeper.RemoveItem(id);
            Console.WriteLine(removed ? "Product removed." : "Product not found.");
        }

        private void FindProduct()
        {
            Console.Write("Product name: ");
            var name = Console.ReadLine() ?? string.Empty;
            var product = _storekeeper.FindProduct(name);

            Console.WriteLine(product == null
                ? "Product not found."
                : $"[{product.GetType().Name}] {product}");
        }

        private static void PrintProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"[{product.GetType().Name}] {product}");
            }
        }
    }
}
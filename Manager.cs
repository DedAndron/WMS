namespace WMS
{
    interface IFinanceControl
    {
        void MakeReport();
        void ShowProfitStatistics();
        void ChangePrice(Product product, decimal newPrice);
    }

    internal class Manager : Worker, IFinanceControl
    {
        public Manager(string name) : base(name) { }

        public void MakeReport()
        {
            Console.WriteLine("Manager is making a financial report...");
        }

        public void ShowProfitStatistics()
        {
            Console.WriteLine("Showing profit statistics...");
        }

        public void ChangePrice(Product product, decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(newPrice), "Price cannot be negative.");

            product.Price = newPrice;
            Console.WriteLine($"Price for {product.Name} changed to {newPrice}");
        }
    }
}

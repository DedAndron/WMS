namespace WMS
{
    internal class PerishableProduct : Product
    {
        public DateTime ExpiryDate { get; set; }

        public PerishableProduct()
        {
            ExpiryDate = DateTime.Today;
        }

        public PerishableProduct(DateTime expiryDate)
        {
            ExpiryDate = expiryDate;
        }

        public override void GetStorageRequirements()
        {
            Console.WriteLine($"Storage requirements: keep refrigerated. Expiry date: {ExpiryDate:yyyy-MM-dd}.");
        }
    }
}
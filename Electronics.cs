namespace WMS
{
    internal class Electronics : Product
    {
        public int WarrantyPeriod { get; set; }
        public int Voltage { get; set; }

        public override void GetStorageRequirements()
        {
            Console.WriteLine("Storage requirements: keep in dry room, avoid overheating.");
        }
    }
}

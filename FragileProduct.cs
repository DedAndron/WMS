namespace WMS
{
    internal class FragileProduct : Product
    {
        public int MaxStakingHeight { get; set; }

        public override void GetStorageRequirements()
        {
            Console.WriteLine("Storage requirements: handle with care, do not stack above allowed height.");
        }
    }
}

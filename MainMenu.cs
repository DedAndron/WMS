using System;

namespace WMS
{
    internal abstract class MainMenu
    {
        protected static int ReadOperationNumber()
        {
            Console.Write("Choose operation: ");
            return int.TryParse(Console.ReadLine(), out var operation) ? operation : -1;
        }

        public abstract void ShowMenu();
        public abstract void ExecuteOperation(int operation);

        public void Start()
        {
            while (true)
            {
                ShowMenu();
                var operation = ReadOperationNumber();

                if (operation == 0)
                {
                    Console.WriteLine("Exit from menu.");
                    break;
                }

                ExecuteOperation(operation);
                Console.WriteLine();
            }
        }
    }
}

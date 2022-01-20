using System;
using Task2.Comands;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            while (true) 
            {
                invoker.SetCommand(Helper.GetCommand(Console.ReadLine().Split(' ')));
                invoker.Run();
            }
        }
    }
}

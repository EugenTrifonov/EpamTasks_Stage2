using System;
using Task2.Comands;

namespace Task2
{
    class Program
    {
        public static bool status=true;

        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            
            while (status) 
            {
                try
                {
                    invoker.SetCommand(CommandFactory.GetCommand(Console.ReadLine().Split(' ')));
                    invoker.Run();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}

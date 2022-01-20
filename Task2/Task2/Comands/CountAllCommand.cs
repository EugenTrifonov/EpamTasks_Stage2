using System;

namespace Task2.Comands
{
    public class CountAllCommand:Command
    {
        public CountAllCommand() : base() { }

        public override void Execute()
        {
            Console.WriteLine("Amount of cars in the park:"+_park.CountAll());
        }
    }
}

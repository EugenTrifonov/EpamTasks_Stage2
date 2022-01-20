using System;

namespace Task2.Comands
{
    public class GetAveragePrice:Command
    {
        public GetAveragePrice() : base() { }

        public override void Execute()
        {
            Console.WriteLine("Average car price:"+ _park.GetAveragePrice());
        }
    }
}

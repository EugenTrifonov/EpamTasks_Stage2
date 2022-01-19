using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

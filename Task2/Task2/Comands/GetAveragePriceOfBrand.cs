using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Comands
{
    public class GetAveragePriceOfBrand:Command
    {
        private string _brand;

        public GetAveragePriceOfBrand(string brand):base()
        {
            _brand = brand; 
        }

        public override void Execute()
        {
            Console.WriteLine($"Average car price of the brand {_brand}:{_park.GetAveragePriceOfBrand(_brand)}");
        }
    }
}

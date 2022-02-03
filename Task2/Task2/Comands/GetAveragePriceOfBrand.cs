using System;

namespace Task2.Comands
{
    public class GetAveragePriceOfBrand:ICommand
    {
        private string _brand;
        private CarPark _park;

        public GetAveragePriceOfBrand(string brand)
        {
            _park = CarPark.GetPark();
            _brand = brand;
        }

        public void Execute()
        {
            Console.WriteLine($"Average car price of brand {_brand}:{_park.GetAveragePriceOfBrand(_brand)}");
        }
    }
}

using System;

namespace Task2.Comands
{
    public class GetAveragePrice:ICommand
    {
        private CarPark _park;

        public GetAveragePrice()
        {
            _park = CarPark.GetPark();
        }

        public void Execute()
        {
            Console.WriteLine("Average car price:"+ _park.GetAveragePrice());
        }
    }
}

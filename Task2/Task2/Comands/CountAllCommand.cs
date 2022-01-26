using System;

namespace Task2.Comands
{
    public class CountAllCommand:ICommand
    {
        private CarPark _park;

        public CountAllCommand()
        {
            _park = CarPark.GetPark();
        }

        public void Execute()
        {
            Console.WriteLine("Amount of cars in the park:"+_park.CountAll());
        }
    }
}
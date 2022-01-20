using System;

namespace Task2.Comands
{
    public class CountTypesCommand:ICommand
    {
        private CarPark _park;

        public CountTypesCommand()
        {
            _park = CarPark.GetPark();
        }

        public void Execute() 
        {
            Console.WriteLine("Amount of types in the park: "+_park.CountTypes());
        }
    }
}

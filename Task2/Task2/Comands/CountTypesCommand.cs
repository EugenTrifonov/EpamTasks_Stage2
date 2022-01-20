using System;

namespace Task2.Comands
{
    public class CountTypesCommand:Command
    {
        public CountTypesCommand() : base() { }

        public override void Execute() 
        {
            Console.WriteLine("Amount of types in the park: "+_park.CountTypes());
        }
    }
}

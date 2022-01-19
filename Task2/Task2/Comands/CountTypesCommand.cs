using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

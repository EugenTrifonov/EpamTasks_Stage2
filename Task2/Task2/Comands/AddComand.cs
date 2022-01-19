using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Comands
{
    public class AddComand:Command
    {
        private Car _car;

        public AddComand(Car car):base()
        {
            _car = car;
        }

        public override void Execute()  
        {
            _park.Add(_car);     
        }
    }
}

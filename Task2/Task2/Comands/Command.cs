using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Comands
{
    public abstract class Command
    {
        protected CarPark _park;

        public Command()
        {
            _park = CarPark.GetPark();
        }
        public abstract void Execute();
    }
}

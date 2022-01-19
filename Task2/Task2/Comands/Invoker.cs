using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Comands
{
    public class Invoker
    {
        private Command _command;

        public void SetCommand(Command command) 
        {
            _command = command;
        }

        public void Run() 
        {
            _command.Execute();
        }
    }
}

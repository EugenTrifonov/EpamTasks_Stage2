using System;

namespace Task2.Comands
{
    public class ExitCommand:Command
    {
        public override void Execute() 
        {
            Environment.Exit(0);
        }
    }
}

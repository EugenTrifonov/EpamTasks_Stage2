using System;

namespace Task2.Comands
{
    public class IncorrectCommand:Command
    {
        private string _text;

        public IncorrectCommand(string text)
        {
            _text = text;
        }

        public override void Execute()
        {
            Console.WriteLine(_text);
        }
    }
}

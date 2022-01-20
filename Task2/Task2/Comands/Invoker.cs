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

namespace Task2.Comands
{
    public class Invoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command) => _command = command;

        public void Run() 
        {
            _command.Execute();
        }
    }
}

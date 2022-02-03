namespace Task2.Comands
{
    public class ExitCommand:ICommand
    {
        public void Execute() 
        {
            Program.status = false;
        }
    }
}

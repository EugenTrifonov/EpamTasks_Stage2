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

namespace Task2.Comands
{
    public class AddComand:ICommand
    {
        private Car _car;

        private CarPark _park;

        public AddComand(Car car)
        {
            _park = CarPark.GetPark();
            _car = car;
        }

        public void Execute()  
        {
            _park.Add(_car);     
        }
    }
}

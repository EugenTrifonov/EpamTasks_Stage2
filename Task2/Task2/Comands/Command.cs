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

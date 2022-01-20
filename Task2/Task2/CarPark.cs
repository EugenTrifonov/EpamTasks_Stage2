using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class CarPark
    {
        private static CarPark _park;

        public List<Car> CarList;

        private CarPark()
        {
            CarList = new List<Car>();
        }

        public static CarPark GetPark()
        {
            if (_park == null)
            {
                _park = new CarPark();
            }

            return _park;
        }

        public void Add(Car car)
        {
            CarList.Add(car);
        }

        public int CountTypes()
        {
            return CarList.Select(x => x.Brand).Distinct().Count();
        }

        public int CountAll()
        {
            return CarList.Sum(x => x.Amount);
        }

        public double GetAveragePrice()
        {
            double price = 0;

            foreach (Car car in CarList)
            {
                price += car.Amount * car.Price;
            }

            return (double)price / CountAll();
        }

        public double GetAveragePriceOfBrand(string type)
        {
            List<Car> selectedCars = CarList.Where(x => x.Brand == type).ToList();

            double price = 0;
            int amount = 0;

            foreach (Car car in selectedCars)
            {
                price += car.Amount * car.Price;
                amount += car.Amount;
            }

            return (double)price / (amount);
        }
    }
}

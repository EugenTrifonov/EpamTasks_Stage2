using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    public class CarPark
    {
        private static CarPark _park;

        private List<Car> _carList;

        private CarPark()
        {
            _carList = new List<Car>();
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
            _carList.Add(car);
        }

        public int CountTypes()
        {
            return _carList.Select(x => x.Brand).Distinct().Count();
        }

        public int CountAll()
        {
            return _carList.Sum(x => x.Amount);
        }

        public double GetAveragePrice()
        {
            double price = 0;

            foreach (Car car in _carList)
            {
                price += car.Amount * car.Price;
            }

            return (double)price / CountAll();
        }

        public double GetAveragePriceOfBrand(string type)
        {
            List<Car> selectedCars = _carList.Where(x => x.Brand == type).ToList();

            if (selectedCars.Count==0)
            {
                throw new Exception($"No car with brand:{type} has been found");
            }

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

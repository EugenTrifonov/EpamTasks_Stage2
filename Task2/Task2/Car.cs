using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Car
    {
        private int _amount;
        private int _price;

        public string Brand { get; set; }

        public string Model { get; set; }

        public int Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Amount can't be negative");
                }
                _amount = value;
            }
        }
        public int Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Price can't be negative");
                }
                _price = value;
            }
        }

        public Car(string brand, string model, int amount, int price)
        {
            Brand = brand;
            Model = model;
            Amount = amount;
            Price = price;
        }
    }
}

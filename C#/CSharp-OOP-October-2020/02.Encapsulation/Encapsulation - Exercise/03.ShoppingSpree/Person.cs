using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;
        public Person(string name, double money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }

        public double Money
        {
            get
            {
                return this.money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (CanAfford(product))
            {
                products.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        private bool CanAfford(Product product)
        {
            if (this.Money >= product.Cost)
            {
                return true;
            }

            return false;
        }
        private bool HasProductsInTheBag()
        {
            if (this.products.Count > 0)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!HasProductsInTheBag())
            {
                return $"{this.Name} - Nothing bought";
            }
            sb.Append($"{this.Name} - {string.Join(", ", this.products)}");

            return sb.ToString().TrimEnd();
        }

    }
}

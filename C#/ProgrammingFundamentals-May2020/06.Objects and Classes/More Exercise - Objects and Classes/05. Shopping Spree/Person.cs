using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Shopping_Spree
{
    class Person
    {
        public string Name { get; set; }

        public decimal Money { get; set; }

        public List<string> Products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            Products = new List<string>();
        }

        public override string ToString()
        {
            if (this.Products.Count == 0)
            {
                return $"{this.Name} - Nothing bought";

            }
            return $"{this.Name} - {string.Join(", ", Products)}";
        }

    }
}

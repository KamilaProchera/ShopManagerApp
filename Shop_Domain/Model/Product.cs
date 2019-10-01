using System;

namespace Shop_Domain
{
    public class Product
    {

        public string Name { get; set; }
        public double Price { get; set; }
        public uint Quantity { get; set; }

        public Product(string name, double price, uint quantity)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Quantity = quantity;
        }
    }
}

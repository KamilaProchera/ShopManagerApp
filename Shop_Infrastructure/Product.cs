using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Shop_Infrastructure
{
    public class Product
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }




        public string Name { get; set; }
        public double Price { get; set; }
        public uint Quantity { get; set; }

        public Product(string id, string name, double price, uint quantity)
        {

            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;

        }
        public Product(string name, double price, uint quantity)
        {

            Name = name;
            Price = price;
            Quantity = quantity;

        }


    }
}

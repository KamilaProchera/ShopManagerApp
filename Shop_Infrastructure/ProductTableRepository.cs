using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Shop_Infrastructure
{
    public class ProductTableRepository
    {
        private readonly IMongoDatabase _database;


        public ProductTableRepository(string database)
        {
            var client = new MongoClient();
            _database = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = _database.GetCollection<T>(table);
            collection.InsertOne(record);
        }
        public void ReadTableFromDb()
        {

            var recs = LoadRecords<Product>("Products");
            for (int i = 0; i < recs.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {recs[i].Name} - Price: {recs[i].Price} - Quantity: {recs[i].Quantity}");
            }
        }


        public List<T> LoadRecords<T>(string table)
        {
            var collection = _database.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public void UpdateRecord(string table, string recond, uint productsQuantity)
        {
            var collection = _database.GetCollection<BsonDocument>(table);
            var builder = Builders<BsonDocument>.Filter.Eq("Name", recond);
            var update = Builders<BsonDocument>.Update.Set("Quantity", productsQuantity);
            collection.UpdateMany(builder, update);


        }

    }

}

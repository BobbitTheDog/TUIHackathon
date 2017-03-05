using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TUIAirportExperience
{
    public class MongoManager
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        protected MongoCredential auth;

        public MongoManager()
        {
            _client = new MongoClient("mongodb://Robert:Skl1@127.0.0.1/TUI_DB");

            _database = _client.GetDatabase("TUI_DB");
        }

        internal List<BsonDocument> GetOrderList()
        {
            var orders = _database.GetCollection<BsonDocument>("Orders");
            FilterDefinition<BsonDocument> orderFilter = Builders<BsonDocument>.Filter.Empty;
            return orders.Find(orderFilter).ToList<BsonDocument>();
        }

        public string[] getCustomer(string query)
        {
            var collection = _database.GetCollection<BsonDocument>("Customers");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", query);
            Console.WriteLine("Filter set");

            var results = collection.Find(filter).ToList<BsonDocument>();

            Console.WriteLine("Search over...");
            Console.WriteLine(results.Count.ToString());

            if (results.Count == 1)
            {
                BsonDocument doc = results[0];

                string[] customer = {
                    doc.GetValue("name").AsString,
                    doc.GetValue("flight").AsDouble.ToString(),
                    doc.GetValue("seatNo").AsDouble.ToString()
                };
                return customer;
                //return doc.GetValue(doc.IndexOfName("name")).AsString;

                // TODO: Add the other fields, bro
            }
            else return null;
        }

        internal BsonDocument getOrderCustomer(string orderID)
        {
            var orders = _database.GetCollection<BsonDocument>("Orders");
            FilterDefinition<BsonDocument> orderFilter = Builders<BsonDocument>.Filter.Eq("_id",orderID);
            BsonDocument order = orders.Find(orderFilter).ToList<BsonDocument>()[0];

            string custID = order.GetElement("customer_id").Value.AsString;

            var customers = _database.GetCollection<BsonDocument>("Customers");
            Console.WriteLine("Checking for customer: " + custID);
            FilterDefinition<BsonDocument> customerFilter = Builders<BsonDocument>.Filter.Eq("_id", custID);
            List<BsonDocument> results = customers.Find(customerFilter).ToList<BsonDocument>();

            return results[0];
        }

        internal BsonDocument getOrder(string orderID)
        {
            var collection = _database.GetCollection<BsonDocument>("Orders");
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", orderID);

            List<BsonDocument> orders = collection.Find(filter).ToList<BsonDocument>();
            return orders[0];
        }

        public List<BsonDocument> getItems()
        {
            return getItems(null);
        }

        public List<BsonDocument> getItems(string category)
        {
            var collection = _database.GetCollection<BsonDocument>("Items");
            FilterDefinition<BsonDocument> filter;
            if (category != null)
            {
                filter = Builders<BsonDocument>.Filter.Eq("category", category);
            }
            else
            {
                filter = Builders<BsonDocument>.Filter.Empty;
            }
            
            var results = collection.Find(filter).ToList<BsonDocument>();
            return results;
        }

        internal void placeOrder(string custID, Dictionary<string, int> order, double total)
        {
            //find out size of current Orders collection, in order to assign id number
            var collection = _database.GetCollection<BsonDocument>("Orders");
            FilterDefinition<BsonDocument> filter;
            filter = Builders<BsonDocument>.Filter.Empty;

            int count = collection.Find(filter).ToList<BsonDocument>().Count;

            BsonArray items = new BsonArray();

            foreach (string key in order.Keys){
                items.Add(
                    new BsonDocument
                    {
                        { "_id", key },
                        { "quantity", order[key] }
                    }
                    );
            }

            var document = new BsonDocument
            {
                { "_id", count.ToString() },
                { "customer_id", custID },
                { "items", items },
                { "price",  total }
            };

            collection.InsertOne(document);
        }

        internal BsonDocument getItemByBarcode(string barcode)
        {
            var collection = _database.GetCollection<BsonDocument>("Items");
            FilterDefinition<BsonDocument> filter;
            filter = Builders<BsonDocument>.Filter.Eq("barcode", barcode);
            List<BsonDocument> results = collection.Find(filter).ToList<BsonDocument>();

            if (results.Count == 1)
            {
                return results[0];
            }
            else return null;
        }

        internal void logItemRequest(string barcode)
        {
            var collection = _database.GetCollection<BsonDocument>("ItemRequests");
            FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("barcode", barcode);
            List<BsonDocument> results = collection.Find(filter).ToList<BsonDocument>();

            int count = 0;

            if (results.Count == 1)
            {
                count = results[0].GetElement("count").Value.AsInt32;
            }

            UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.Set("count", count+1);
            UpdateOptions options = new UpdateOptions();
            options.IsUpsert = true;

            collection.UpdateOne(filter, update, options);
            Console.WriteLine("Logged item request.");
        }
    }
}

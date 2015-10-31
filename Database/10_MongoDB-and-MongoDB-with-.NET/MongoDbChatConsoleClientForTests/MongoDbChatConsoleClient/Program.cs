using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MongoDbChatConsoleClient
{
    class Program
    {

        const string DatabaseHost = "mongodb://pesho:pesho@ds063789.mongolab.com:63789/chat-data";
        const string DatabaseName = "chat-data";



        class Message
        {
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            public string Text { get; set; }

            public DateTime Date { get; set; }

            public User user { get; set; }
        }

        static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }

        static void Main()
        {
            var db = GetDatabase(DatabaseName, DatabaseHost);

            var logs = db.GetCollection<Message>("messages");

            logs.Insert(new Message()
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Date = DateTime.Now,
                //Text = "Something important happened",
                Text = "Second message entered!",
                user = new User() { Username = "Pesho" }
            });

            //var update = Update.Set("Text", "Changed Text at " + DateTime.Now);


            //var query = Query.And(
            //    Query.LT("LogDate", DateTime.Now.AddSeconds(-1))
            //    );

            //logs.Update(query, update);

            var results = logs.FindAll()
                            //.Select(l => l.Text)
                            .ToList<Message>();

            foreach (var item in results)
            {
                Console.WriteLine(item.user.Username + ": " + item.Text + " -> " + item.Date);
            }
        }
    }
}

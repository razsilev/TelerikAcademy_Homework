namespace MongoDbData
{
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Linq;

    public class ChatContext
    {

        const string DatabaseHost = "mongodb://pesho:pesho@ds063789.mongolab.com:63789/chat-data";
        const string DatabaseName = "chat-data";

        private MongoDatabase db;

        public ChatContext()
        {
            this.db = GetDatabase(DatabaseName, DatabaseHost);
        }

        public void AddMessage(Message message)
        {
            var messages = this.db.GetCollection<Message>("messages");

            messages.Insert(message);
        }

        public IList<Message> GetAllMessages()
        {
            var messages = this.db.GetCollection<Message>("messages");
            var results = messages.FindAll()
                            .ToList<Message>();

            return results;
        }

        private static MongoDatabase GetDatabase(string name, string fromHost)
        {
            var mongoClient = new MongoClient(fromHost);
            var server = mongoClient.GetServer();
            return server.GetDatabase(name);
        }
    }
}

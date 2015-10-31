namespace MongoDbData
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;

    public class Message
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public User user { get; set; }

        public override string ToString()
        {
            return string.Format("{0}      {1}\n{2}\n\n", this.user.Username, this.Date, this.Text);
        }
    }
}

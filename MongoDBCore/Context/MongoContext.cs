using MongoDB.Driver;
using WebAPICoreMongoDb.Models;

namespace WebAPICoreMongoDb
{
    public class MongoContext<T> where T : class
    {
        private readonly IMongoDatabase database;

        public MongoContext()
        {
            database = new MongoClient(Startup.ConnectionString).GetDatabase("Users");
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return database.GetCollection<User>("Users");
            }
        }
    }
}

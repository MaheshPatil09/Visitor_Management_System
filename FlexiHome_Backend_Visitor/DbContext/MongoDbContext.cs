using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FlexiHome_Backend_Visitor.Helper;
using FlexiHome_Backend_Visitor.VisitorEntity;
namespace FlexiHome_Backend_Visitor.DbContext
{
    public class MongoDbContext
    {
         private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }
        public IMongoCollection<VisitorEntityClass> visitors =>
            _database.GetCollection<VisitorEntityClass>("visitors");
    }
}

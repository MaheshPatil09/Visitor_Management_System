using FlexiHome_Backend_Visitor.VisitorEntity;
using FlexiHome_Backend_Visitor.DbContext;
using Microsoft.Extensions.Options;
using FlexiHome_Backend_Visitor.Helper;
using MongoDB.Driver;
using System.Runtime.InteropServices;

namespace FlexiHome_Backend_Visitor.DatabaseLayer
{
    public class Database : IDatabase
    {

        private readonly MongoDbContext _mongoDbContext;
        public Database(IOptions<MongoDbSettings> settings) 
        {
            _mongoDbContext = new MongoDbContext(settings);
        }
        public async Task  AddVisitorInSocietyAsyncDb(VisitorEntityClass visitorEntityClass)
        {
           await _mongoDbContext.visitors.InsertOneAsync(visitorEntityClass);
           
        }
        public async Task<bool> CheckUniqueIdAsPreviousOneDb(string id)
        {
            return  await _mongoDbContext.visitors.Find(v => v.Id == id).AnyAsync();    
        }

        public async Task DeleteVisitorInSocietyDb(string id)
        {
            await _mongoDbContext.visitors.DeleteOneAsync(v => v.Id == id);
        }

        public async  Task<List<VisitorEntityClass>> GetAllVisitorsInSocietyAsyncDb()
        {
             return await _mongoDbContext.visitors.Find(_ => true).ToListAsync();
        }
        public async Task<VisitorEntityClass> GetVisitorInSocietyAsyncDb(string id)
        {
            return await _mongoDbContext.visitors.Find(v => v.Id == id).SingleOrDefaultAsync();
        }

        public async   Task UpdateVisitorInSocietyAsyncDb(string visitorId ,VisitorEntityClass visitorEntityClass)
        {
            await _mongoDbContext.visitors.ReplaceOneAsync(v => v.Id == visitorId , visitorEntityClass);
        }
    }
}

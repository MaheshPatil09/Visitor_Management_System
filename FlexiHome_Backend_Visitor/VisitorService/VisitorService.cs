using FlexiHome_Backend_Visitor.VisitorModel;
using FlexiHome_Backend_Visitor.VistorInterface;
using MongoDB.Driver;
using FlexiHome_Backend_Visitor.DatabaseLayer;
using AutoMapper;
using FlexiHome_Backend_Visitor.VisitorEntity;
using System.Runtime.CompilerServices;
using System.Xml;

namespace FlexiHome_Backend_Visitor.VisitorService
{
    public class VisitorService : IVisitor
    {
         private readonly IDatabase _database;
         private readonly IMapper _mapper;
        private readonly ILogger<VisitorService> _logger;
        public VisitorService(IDatabase database , IMapper mapper , ILogger<VisitorService> logger)
        {
            _database = database;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<VisitorModelClass> AddVisitorInSocietyAsync(VisitorModelClass visitorModelClass)
        {
            string uniqueId = string.Empty; // Declare and initialize uniqueId outside the try block

            try
            {
                uniqueId = await GenerateUniqueIdAsync();
                var visitorEntity = _mapper.Map<VisitorEntityClass>(visitorModelClass);
                visitorEntity.Id = uniqueId; // Assign the generated unique ID to the entity
                await _database.AddVisitorInSocietyAsyncDb(visitorEntity);
                return visitorModelClass;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while adding the visitor to the society with Unique ID: {uniqueId}. Exception: {ex.Message}");
                throw;
            }
        }

        public async  Task<string?> DeleteVisitorInSociety(string id)
        {
            try
            {
                var visitorEntity = await _database.GetVisitorInSocietyAsyncDb(id);
                if(visitorEntity != null)
                {
                    await _database.DeleteVisitorInSocietyDb(id);
                    return "Visitor Deleted Successfully ";
                }
                return null;
            }catch(Exception ex)
            {
                _logger.LogError($"An Error Occured While Deleting The Visitor In Society With The Visitor Id : {id}.Error :{ex.Message}", ex);
                throw;
            }
        }

        public async Task<List<VisitorModelClass>> GetAllVisitorsInSocietyAsync()
        {
            try
            {
                var visitorsInSociety = await _database.GetAllVisitorsInSocietyAsyncDb();
                if( visitorsInSociety != null &&  visitorsInSociety.Any())
                {
                        return _mapper.Map<List<VisitorModelClass>>(visitorsInSociety);
                }
                return new List<VisitorModelClass>();
            }
            catch (Exception ex) 
            {
                _logger.LogError($"The Error Occured While Fetching The Visitors In The Society ");
                 throw;
            }
        }

        public async Task<VisitorModelClass?> GetVisitorInSocietyAsync(string id)
        {
            try
            {
                var visitorInSociety = await  _database.GetVisitorInSocietyAsyncDb(id);
                if (visitorInSociety != null) 
                {
                    return _mapper.Map<VisitorModelClass>(visitorInSociety);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Error Occured While Fetching The Visitor In Society With The Given ID : {id}.Error :{ex.Message}", ex);
                throw;
            }
        }

        public async  Task<VisitorModelClass?> UpdateVisitorInSocietyAsync(string visitorId, VisitorModelClass visitorModelClass)
        {
            try
            {
                var visitorEntity = await _database.GetVisitorInSocietyAsyncDb(visitorId);
                if(visitorEntity != null)
                {
                     _mapper.Map(visitorModelClass, visitorEntity);
                     await _database.UpdateVisitorInSocietyAsyncDb(visitorId ,visitorEntity);
                    return _mapper.Map<VisitorModelClass>(visitorEntity);
                }
                return null;
            }catch (Exception ex)
            {
                _logger.LogError($"An Error Occured While Updating The Visitor In Society With The Visitor Id : {visitorId}.Error :{ex.Message}",ex);
                throw;
            }
        }

        private async Task<string> GenerateUniqueIdAsync()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            string id;

            do
            {
                id = new string(Enumerable.Repeat(chars, 6)
                                          .Select(s => s[random.Next(s.Length)]).ToArray());
            } while (await _database.CheckUniqueIdAsPreviousOneDb(id)); 

            return id;
        }

    }
}

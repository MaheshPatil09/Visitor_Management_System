using FlexiHome_Backend_Visitor.VisitorEntity;

namespace FlexiHome_Backend_Visitor.DatabaseLayer
{
    public interface IDatabase
    {
           Task  AddVisitorInSocietyAsyncDb(VisitorEntityClass visitorEntityClass);
           Task<bool> CheckUniqueIdAsPreviousOneDb(string id);
          Task<List<VisitorEntityClass>> GetAllVisitorsInSocietyAsyncDb();
          Task<VisitorEntityClass> GetVisitorInSocietyAsyncDb(string id);
        Task UpdateVisitorInSocietyAsyncDb(string visitorId ,VisitorEntityClass visitorEntityClass);
        Task DeleteVisitorInSocietyDb(string id);


    }
}

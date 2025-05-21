using FlexiHome_Backend_Visitor.VisitorModel;

namespace FlexiHome_Backend_Visitor.VistorInterface
{
    public interface IVisitor
    {
        Task<VisitorModelClass> AddVisitorInSocietyAsync(VisitorModelClass visitorModelClass);

        Task<List<VisitorModelClass>> GetAllVisitorsInSocietyAsync();

        Task<VisitorModelClass> GetVisitorInSocietyAsync(string id);

        Task<VisitorModelClass> UpdateVisitorInSocietyAsync(string  visitorId, VisitorModelClass visitorModelClass);
         Task<string> DeleteVisitorInSociety(string id);
    }
}

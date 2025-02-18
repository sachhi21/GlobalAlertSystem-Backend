using DomainLayer;
using DomainLayer.Model;
using System.Linq.Expressions;

namespace WebAlertApi.IServices
{
    public interface IIncidentService
    {
        Task Delete(Incident entity);
        Task<Incident?> Get<C>(C Id);
        Task InsertDaister(NaturalDisaster entity);
        Task<IEnumerable<Incident>> GetAll();
        Task Insert(Incident entity);
        Task Remove(Incident entity);
        Task Update(Incident entity);
        Task<IEnumerable<Incident>> Search(Expression<Func<Incident, bool>> predicate);
        Task InsertManmadeAccident(ManMadeIncident entity); 
        Task InsertHealthIncident(HealthIncident entity);
        Task InsertCyberIncident(CybersecurityIncident entity);
    }
}

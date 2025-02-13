using DomainLayer;
using System.Linq.Expressions;

namespace WebAlertApi.IServices
{
    public interface IIncidentService
    {
        Task Delete(Incident entity);
        Task<Incident?> Get<C>(C Id);
        Task<IEnumerable<Incident>> GetAll();
        Task Insert(Incident entity);
        Task Remove(Incident entity);
        Task Update(Incident entity);
        Task<IEnumerable<Incident>> Search(Expression<Func<Incident, bool>> predicate);
    }
}

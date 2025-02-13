using DomainLayer;
using RepositoryLayer.IRepository;
using System.Linq.Expressions;
using WebAlertApi.IServices;

namespace WebAlertApi.Services
{
    public class IncidentService :  IIncidentService
    {
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _applicationDbContext;

        public IncidentService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Delete(Incident entity)
        {
            await _repository.Delete<Incident>(entity);
        }

        public async Task<Incident?> Get<C>(C Id)
        {
            return await _repository.Get<C, Incident>(Id);
        }

        public async Task<IEnumerable<Incident>> GetAll()
        {
            return await _repository.GetAll<Incident>();
        }
        public async Task Insert(Incident entity)
        {
            await _repository.Insert<Incident>(entity);

        }

        public async Task Remove(Incident entity)
        {
            await _repository.Remove<Incident>(entity);
        }

        public async Task Update(Incident entity)
        {
            await _repository.Update(entity);
        }

        public async Task<IEnumerable<Incident>> Search(Expression<Func<Incident, bool>> predicate)
        {
            return await _repository.Search(predicate);
        }
    }
}

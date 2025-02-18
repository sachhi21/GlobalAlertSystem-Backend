using Azure;
using DomainLayer;
using DomainLayer.Model;
using RepositoryLayer.IRepository;
using System.Linq.Expressions;
using WebAlertApi.Controllers;
using WebAlertApi.IServices;
using WebAlertApi.Models.Response;

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
            try
            {
              
                await _repository.Insert<Incident>(entity);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine(ex.InnerException?.Message);
            }


        }

        public async Task InsertDaister(NaturalDisaster entity)
        {
            try
            {

                await _repository.Insert<NaturalDisaster>(entity);
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine(ex.InnerException?.Message);
            }

        }

        public async Task Remove(Incident entity)
        {
            //await _repository.Remove<Location>(entity.Location);

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

        public async Task InsertManmadeAccident(ManMadeIncident entity)
        {
            await _repository.Insert(entity);
        }
        public async Task InsertHealthIncident(HealthIncident entity)
        {
            await _repository.Insert(entity);
        }
        public async Task InsertCyberIncident(CybersecurityIncident entity)
        {
            await _repository.Insert(entity);
        }
    }
}

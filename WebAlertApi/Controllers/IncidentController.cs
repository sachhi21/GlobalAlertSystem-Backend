using DomainLayer;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebAlertApi.IServices;
using WebAlertApi.Models.Response;

namespace WebAlertApi.Controllers
{
    [Route("alert/api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentService _IncidentService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public IncidentController( 
            ApplicationDbContext applicationDbContext, IIncidentService IncidentService, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            _IncidentService = IncidentService;
        }

        [HttpGet(nameof(GetIncidentById))]
        public async Task<IActionResult> GetIncidentById(int Id)
        {
            APIResponse<Incident> response;

            try
            {
                var obj = await _IncidentService.Get(Id);
                response = new APIResponse<Incident>(true, obj);
            }
            catch (Exception ex)
            {
                response = new APIResponse<Incident>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpGet(nameof(GetAllIncidents))]
        public async Task<IActionResult> GetAllIncidents()
        {
            APIResponse<IEnumerable<Incident>> response;
            try
            {
                var obj = await _IncidentService.GetAll();
                response = new APIResponse<IEnumerable<Incident>>(true, obj);
            }
            catch (Exception ex)
            {
                response = new APIResponse<IEnumerable<Incident>>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpPost(nameof(InsertIncident))]
        public async Task<IActionResult> InsertIncident(Incident entity)
        {
            APIResponse<Incident> response;
            try
            {
                await _IncidentService.Insert(entity);
                response = new APIResponse<Incident>(true, entity);
            }
            catch (Exception ex)
            {
                response = new APIResponse<Incident>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpPut(nameof(UpdateIncident))]
        public async Task<IActionResult> UpdateIncident(Incident entity)
        {
            APIResponse<Incident> response;
            try
            {
                await _IncidentService.Update(entity);
                response = new APIResponse<Incident>(true, entity);
            }
            catch (Exception ex)
            {
                response = new APIResponse<Incident>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpDelete(nameof(DeleteIncident))]
        public async Task<IActionResult> DeleteIncident(Incident entity)
        {
            APIResponse<Incident> response;
            try
            {
                await _IncidentService.Delete(entity);
                response = new APIResponse<Incident>(true, entity);
            }
            catch (Exception ex)
            {
                response = new APIResponse<Incident>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpPost(nameof(SearchIncident))]
        public async Task<IActionResult> SearchIncident(Expression<Func<Incident, bool>> predicate)
        {
            APIResponse<IEnumerable<Incident>> response;
            try
            {
                var obj = await _IncidentService.Search(predicate);
                response = new APIResponse<IEnumerable<Incident>>(true, obj);
            }
            catch (Exception ex)
            {
                response = new APIResponse<IEnumerable<Incident>>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpGet(nameof(SearchIncident))]
        public async Task<IActionResult> SearchIncident(string search)
        {
            APIResponse<IEnumerable<Incident>> response;
            try
            {
                var obj = await _IncidentService.Search(x => x.Title.Contains(search));
                response = new APIResponse<IEnumerable<Incident>>(true, obj);
            }
            catch (Exception ex)
            {
                response = new APIResponse<IEnumerable<Incident>>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }


    }
}

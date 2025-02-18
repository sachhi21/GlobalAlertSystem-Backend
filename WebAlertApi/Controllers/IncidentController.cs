using DomainLayer;
using DomainLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WebAlertApi.IServices;
using WebAlertApi.Models.Response;
using WebAlertApi.Services;

namespace WebAlertApi.Controllers
{
    [Route("alert/api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly ILogger<IncidentController> _logger;

        private readonly IIncidentService _IncidentService;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;
        public IncidentController(
            ApplicationDbContext applicationDbContext, IIncidentService IncidentService, IConfiguration configuration,ILogger<IncidentController> logger)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
            _IncidentService = IncidentService;
            _logger = logger;
        }

        [HttpGet("GetIncidentById")]

        public async Task<IActionResult> GetIncidentById(Guid Id)
        {
            APIResponse<Incident> response;
            _logger.LogInformation("GetIncidentById");
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
            _logger.LogInformation("Adding Incident Report");

            try
            {
                await _IncidentService.Insert(entity);
                response = new APIResponse<Incident>(true, entity);
                _logger.LogInformation(" Incident Report Added"+ response.Data.Id);

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

        [HttpPost(nameof(InsertNaturalDaister))]
        public async Task<IActionResult> InsertNaturalDaister(NaturalDisaster entity)
        {
            APIResponse<NaturalDisaster> response;
            _logger.LogInformation("Adding Incident Report");

            try
            {
                await _IncidentService.InsertDaister(entity);
                response = new APIResponse<NaturalDisaster>(true, entity);
                _logger.LogInformation(" Incident Report Added" + response.Data.Id);

            }
            catch (Exception ex)
            {
                response = new APIResponse<NaturalDisaster>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }

        [HttpPost(nameof(InsertManMadeAccident))]
        public async Task<IActionResult> InsertManMadeAccident(ManMadeIncident entity)
        {
            APIResponse<ManMadeIncident> response;
            _logger.LogInformation("Adding Incident Report");

            try
            {
                await _IncidentService.InsertManmadeAccident(entity);
                response = new APIResponse<ManMadeIncident>(true, entity);
                _logger.LogInformation(" Incident Report Added" + response.Data.Id);

            }
            catch (Exception ex)
            {
                response = new APIResponse<ManMadeIncident>(false, new string[] { ex.Message });
            }
            return Ok(response);
        }


    }
}

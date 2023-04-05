using Domain.Logger;
using Microsoft.AspNetCore.Mvc;
using Services.ScheduleService;
using Services.LocationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IScheduleService _ScheduleService;

        public SchedulesController(ILoggerManager logger, IScheduleService ScheduleService)
        {
            _logger = logger;
            _ScheduleService = ScheduleService;
        }
        // GET: api/<SchedulesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInfo("Fetching all the Schedules from the storage");
            var Schedules = await _ScheduleService.GetAllSchedulesAsync();
            _logger.LogInfo($"Returning {Schedules.Count} Schedules.");
            return Ok(Schedules);
        }
    }
}

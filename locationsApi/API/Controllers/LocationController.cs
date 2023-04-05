using Domain.DTOs;
using Domain.Logger;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Services.LocationService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ILoggerManager _logger;
        private ILocationService _LocationService;
        private IValidator<SaveLocationPayload> _validator;
        private IValidator<EditLocationPayload> _validatorEdit;
        public LocationsController(ILoggerManager logger, ILocationService LocationService, IValidator<SaveLocationPayload> validator, IValidator<EditLocationPayload> validatorEdit)
        {
            _logger = logger;
            _LocationService = LocationService;
            _validator = validator;
            _validatorEdit = validatorEdit;
        }

        // GET: api/<LocationsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInfo("Fetching all the Locations from the storage");
            var Locations = await _LocationService.GetAllLocationsAsync();
            _logger.LogInfo($"Returning {Locations.Count} Locations.");
            return Ok(Locations);
        }

        // GET: api/GetBetweenTimes
        [HttpGet]
        [Route("GetBetweenTimes")]
        public async Task<IActionResult> GetBetweenTimes()
        {
            _logger.LogInfo("Fetching Locations in Range of Time");
            var Locations = await _LocationService.GetLocationsBetweenTimesAsync();
            _logger.LogInfo($"Returning {Locations.Count} Locations.");
            return Ok(Locations);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInfo("Fetching all the Locations from the storage");
            var Location = await _LocationService.GetLocationAsync(id);
            return Ok(Location);
        }



        // POST api/<LocationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveLocationPayload payload)
        {
            ValidationResult result = await _validator.ValidateAsync(payload);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }            
            var response = await _LocationService.SaveLocationAsync(payload);
            return Ok(response);
        }

        // PUT api/<LocationsController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditLocationPayload payload)
        {
            ValidationResult result = await _validatorEdit.ValidateAsync(payload);
            if (!result.IsValid)
            {
                return BadRequest(result);
            }
            var response = await _LocationService.EditLocationAsync(payload);
            return Ok(response);
        }

        // DELETE api/<LocationsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _LocationService.DeleteLocationAsync(id);
            return Ok(response);
        }
    }
}

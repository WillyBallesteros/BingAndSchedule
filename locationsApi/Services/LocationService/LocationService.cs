using AutoMapper;
using Data;
using Domain.DTOs;
using Domain.Entities;
using Domain.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Services.LocationService
{
    public class LocationService : ILocationService
    {
        private readonly ILocationsApiDbContext _context;
        private readonly IMapper _mapper;

        public LocationService(ILocationsApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponsePackage<bool>> SaveLocationAsync(SaveLocationPayload payload) 
        {
            var response = new ResponsePackage<bool>();
            var cancellationToken = new CancellationToken();            
            payload.Schedules.Add(new ScheduleDto
            {
                Observation = "Creación de Ubicación"
            });

            var Location = _mapper.Map<Location>(payload);            
            await _context!.Locations!.AddAsync(Location, cancellationToken);          
            await _context.SaveChangesAsync(cancellationToken);

            response.Message = "La ubicación fue guardada correctamente";
            response.Result = true;
            return response;
        }

        public async Task<ResponsePackage<bool>> EditLocationAsync(EditLocationPayload payload)
        {
            var response = new ResponsePackage<bool>();
            var cancellationToken = new CancellationToken();

            var Location = await _context!.Locations!.FirstOrDefaultAsync(x => x.Id == payload.Id);

            if (Location == null)
            {
                response.Message = $"La ubicación {payload.Name} no existe";
                response.Result = false;
                return response;
            }

            _mapper.Map(payload, Location);

            await _context!.Schedules!.AddAsync(new Schedule
            {
                Observation = "Actualización de Ubicación",
                LocationId = payload.Id,
            }, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            response.Message = "La ubicación fue actualizado correctamente";
            response.Result = true;
            return response;
        }

        public async Task<List<LocationDto>> GetAllLocationsAsync()
        {
            var Locations = await _context!.Locations!.Include(x => x.Schedules).AsNoTracking().ToListAsync();
            var LocationsDto = _mapper.Map<List<LocationDto>>(Locations);
            return LocationsDto;
        }

        public async Task<List<LocationDto>> GetLocationsBetweenTimesAsync()
        {
            TimeSpan open = TimeSpan.FromHours(10);
            TimeSpan close = TimeSpan.FromHours(13);
            var locations = await _context!.Locations!.Include(x => x.Schedules).ToListAsync();
            foreach (var location in locations)
            {
                var availableSchedule = location.Schedules!.Where(x => x.Open.TotalHours <= open.TotalHours && x.Close.TotalHours >= close.TotalHours).ToList();
                location.Schedules = availableSchedule;
            }
            locations.RemoveAll(o => o.Schedules != null && o.Schedules.Count == 0);
            var LocationsDto = _mapper.Map<List<LocationDto>>(locations);
            return LocationsDto;
        }
        public async Task<LocationDto> GetLocationAsync(int id)
        {
            var Location = await _context!.Locations!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var LocationDto = _mapper.Map<LocationDto>(Location);
            return LocationDto;
        }

        public async Task<ResponsePackage<bool>> DeleteLocationAsync(int id)
        {
            var response = new ResponsePackage<bool>();
            var cancellationToken = new CancellationToken();

            var Location = await _context!.Locations!.Include(x => x.Schedules).FirstOrDefaultAsync(x => x.Id == id);

            if (Location == null)
            {
                response.Message = $"La ubicación con Id: {id} no existe";
                response.Result = false;
                return response;
            }

            if (Location!.Schedules!.Any())
            {
                _context!.Schedules!.RemoveRange(Location!.Schedules);
            }
            _context.Remove(Location);
                                  
            await _context.SaveChangesAsync(cancellationToken);

            response.Message = $"La ubicación {Location.Name}  fue eliminada correctamente";
            response.Result = true;
            return response;
        }
    }
}

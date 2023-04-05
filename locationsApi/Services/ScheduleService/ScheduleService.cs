using AutoMapper;
using Data;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
        private readonly ILocationsApiDbContext _context;
        private readonly IMapper _mapper;

        public ScheduleService(ILocationsApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ScheduleDto>> GetAllSchedulesAsync()
        {
            var Schedules = await _context!.Schedules!
                .Join(_context!.Locations, a => a.LocationId, a => a.Id, (Schedule, Location) => new 
                ScheduleDto()
                {
                    Id = Schedule.Id,
                    Day = Schedule.Day,
                    Open =Schedule.Open.ToString(),
                    Close =Schedule.Close.ToString(),
                    Observation = Schedule.Observation
                }).AsNoTracking().OrderByDescending(x => x.Id).ToListAsync();

            var SchedulesDto = _mapper.Map<List<ScheduleDto>>(Schedules);
            return SchedulesDto;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Services.ScheduleService
{
    public interface IScheduleService
    {
        Task<List<ScheduleDto>> GetAllSchedulesAsync();
    }
}

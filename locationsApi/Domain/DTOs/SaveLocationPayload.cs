using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class SaveLocationPayload
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string? Phone { get; set; }
        public string City { get; set; }
        public ICollection<ScheduleDto> Schedules { get; set; } = new List<ScheduleDto>();
    }
}

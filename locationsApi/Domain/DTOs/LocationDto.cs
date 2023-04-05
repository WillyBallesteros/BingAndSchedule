namespace Domain.DTOs
{
    public class LocationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string? Phone { get; set; }
        public string City { get; set; }
        public IList<ScheduleDto>? Schedules { get; set; }
    }
}

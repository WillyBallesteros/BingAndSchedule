namespace Domain.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public TimeSpan Close { get; set; }
        public TimeSpan Open { get; set; }
        public int LocationId { get; set; }
        public string Observation { get; set; }
    }
}

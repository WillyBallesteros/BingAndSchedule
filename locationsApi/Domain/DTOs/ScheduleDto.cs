namespace Domain.DTOs
{
    public class ScheduleDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Close { get; set; }
        public string Open { get; set; }
        public int LocationId { get; set; }
        public string Observation { get; set; }
    }
}

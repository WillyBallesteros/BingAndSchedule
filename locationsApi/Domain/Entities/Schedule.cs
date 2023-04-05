using Domain.Common;

namespace Domain.Entities
{
    public class Schedule : BaseDomainModel
    {
        public string Day { get; set; }
        public TimeSpan Close { get; set; }
        public TimeSpan Open { get; set; }
        public int LocationId { get; set; }
        public string Observation { get; set; }
        public virtual Location? Location { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Location : BaseDomainModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string? Phone { get; set; }
        public string City { get; set; }
        public ICollection<Schedule>? Schedules { get; set; } = new List<Schedule>();
    }
}

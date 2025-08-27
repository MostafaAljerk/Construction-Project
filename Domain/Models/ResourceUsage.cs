using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ResourceUsage
    {
        public int Id { get; set; }
        public int QuantityUsed { get; set; }
        public DateTime UsageDate { get; set; } = DateTime.Now;
        public ProjectTask ProjectTask { get; set; }
        public int ProjectTaskId { get; set; }
        public Resource Resource { get; set; }
        public int ResourceId { get; set; }
    }
}

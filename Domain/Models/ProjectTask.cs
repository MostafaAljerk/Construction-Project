using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public ConstructionProject ConstructionProject { get; set; }
        public int ConstructionProjectId { get; set; }
        public List<Employee> Employees { get; set; }=new List<Employee>();
        public List<ResourceUsage> ResourceUsages { get; set; } = new List<ResourceUsage>();
    }
}

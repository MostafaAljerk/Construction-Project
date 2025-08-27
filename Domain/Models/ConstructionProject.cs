using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ConstructionProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();
        public List<PaymentTransaction> PaymentTransactions { get; set; }= new List<PaymentTransaction>();
    }
}

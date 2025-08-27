using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class EmployeeProjectTask
    {
        public int EmployeeId { get; set; }
        public int ProjectTaskId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

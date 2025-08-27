using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class PaymentTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public int Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public ConstructionProject ConstructionProject { get; set; }
        public int ConstructionProjectId { get; set; }
    }
}

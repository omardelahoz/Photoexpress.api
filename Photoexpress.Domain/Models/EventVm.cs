using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Domain.Models
{
    public class EventVm
    {
        public Guid Id { get; set; }
        public decimal AdditionalValue { get; set; }
        public decimal BaseValue { get; set; }
        public string InstitutionAddress { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public int NumStudents { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime ActivationDate { get; set; } 
        public DateTime? ExpirationDate { get; set; }

        public EventVm()
        {
            ActivationDate = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
            IsActive = true;
        }
    }
}

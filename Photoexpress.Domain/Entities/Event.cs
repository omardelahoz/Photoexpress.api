using Photoexpress.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Domain.Entities
{
    public class Event : EntityBase
    {
        public decimal AdditionalValue { get; set; }
        public decimal BaseValue { get; set; }
        public string InstitutionAddress { get; set; } = string.Empty;
        public string InstitutionName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public int NumStudents { get; set; }
    }
}

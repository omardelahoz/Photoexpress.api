using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Domain.Models
{
    public class ParameterVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime ActivationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public ParameterVm()
        {
            ActivationDate = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
            IsActive = true;
        }
    }
}

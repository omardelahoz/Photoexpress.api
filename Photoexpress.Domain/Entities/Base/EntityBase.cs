using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Domain.Entities.Base
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public EntityBase() 
        { 
            ActivationDate = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
            IsActive = true;
        }
    }
}

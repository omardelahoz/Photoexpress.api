using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Domain.Entities.Base
{
    public class EntityAudit
    {
        public Guid CreatedBy { get; set; }
        public Guid UpdateBy { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Update { get; set; } = DateTime.Now;
    }
}

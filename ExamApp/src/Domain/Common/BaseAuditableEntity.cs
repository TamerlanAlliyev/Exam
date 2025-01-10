using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseAuditableEntity : BaseEntity
    {
        public int Number { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
    }
}

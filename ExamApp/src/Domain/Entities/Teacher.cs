using Domain.Common;
using ExamApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher : BaseAuditableEntity
    {
  
        public string Specialization { get; set; } = null!;
        public List<SchoolClass>? Classes { get; set; }
        public List<Lesson>? Lessons { get; set; }
    }
}

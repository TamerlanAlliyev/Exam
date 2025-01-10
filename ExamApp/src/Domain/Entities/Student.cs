using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace ExamApp.Domain.Entities;

public class Student:BaseAuditableEntity
{
    public int SchoolClassId { get; set; }
    public SchoolClass SchoolClass { get; set; }=null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.ViewModels.Student;

public class StudentCreateVM
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public int ClassId {  get; set; }
    public IEnumerable<SelectListItem>? Class { get; set; }
    [NotMapped]
    public IFormFile Image { get; set; } = null!;
}

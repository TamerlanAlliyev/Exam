using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamApp.Application.ViewModels.Student;

public class StudentVM
{
    public int Id { get; set; }
    public int Class { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string ImageURL { get; set; } = null!;

}

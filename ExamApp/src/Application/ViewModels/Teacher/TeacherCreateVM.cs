using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ExamApp.Application.ViewModels.Teacher;

public class TeacherCreateVM
{
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string Specialization { get; set; } = null!;
    [NotMapped]
    public IFormFile Image { get; set; } = null!;
}

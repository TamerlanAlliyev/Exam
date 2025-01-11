namespace ExamApp.Application.ViewModels.Teacher;
public class TeacherVM
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string ImageURL { get; set; } = null!;
    public string Specialization { get; set; } = null!;

}

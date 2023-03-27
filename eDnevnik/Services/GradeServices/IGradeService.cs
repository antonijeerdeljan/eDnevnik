using eDnevnik.Model;
using eDnevnik.Services.StudentServices;
using eDnevnik.Services.ValidatorService;

namespace eDnevnik.Services.GradeServices
{
    public interface IGradeService
    {
        List<Grade> AddGrade(IValidator _validator, List<Grade> grades, List<Student> students, List<Subject> subjects);
        Grade CheckForAnyGrades(int id, List<Grade> grades);
        string GetDescriptiveGrade(double grade);
        void PrintGrades(IStudentService studentService, List<Student> students, List<Grade> grades, List<Subject> subjects);
        void PrintSubjectsAndGrades(Student student, List<Subject> subjects, List<Grade> grades);
        List<Grade> SaveGrade(string[] nameParts, string subject, int grade, List<Grade> grades, List<Student> students, List<Subject> subjects);
    }
}
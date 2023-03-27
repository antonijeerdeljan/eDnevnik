using eDnevnik.Model;
using eDnevnik.Services.ValidatorService;

namespace eDnevnik.Services.eDnevnikServices
{
    public interface IeDnevnikServices
    {
        IValidator _validator { get; set; }
        List<Grade> grades { get; set; }
        List<Student> students { get; set; }
        List<Subject> subjects { get; set; }

        void AddGrade();
        void AddStudents();
        Grade CheckForAnyGrades(int id);
        Student FindStudent(string[] nameParts);
        void PrintGrades();
        void PrintSubjects();
        void SaveGrade(string[] nameParts, string subject, int grade);
    }
}
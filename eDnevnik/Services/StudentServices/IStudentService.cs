using eDnevnik.Model;
using eDnevnik.Services.ValidatorService;

namespace eDnevnik.Services.StudentServices
{
    public interface IStudentService
    {
        List<Student> AddStudents(List<Student> students, IValidator validator);
        Student FindStudent(List<Student> students, string[] nameParts);
    }
}
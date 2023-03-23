using eDnevnik.Model;

namespace eDnevnik.Repository.StudentRepository
{
    public interface IStudentRepository
    {
        List<Student> ReturnStudents();
    }
}
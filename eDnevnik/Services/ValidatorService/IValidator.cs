using eDnevnik.Model;

namespace eDnevnik.Services.ValidatorService
{
    public interface IValidator
    {
        List<Student> StudentValidationOnCreating(string[] studentNames);
        bool CheckIfStudentExist(string studentName, string[] nameParts);
        bool CheckIfSubjectExist(string subject);


    }
}
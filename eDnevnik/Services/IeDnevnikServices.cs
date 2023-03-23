namespace eDnevnik.Services
{
    public interface IeDnevnikServices
    {
        void AddGrade();
        void AddStudents();
        bool CheckIfStudentExist(string studentName, string[] nameParts);
        bool CheckIfSubjectExist(string subject);
        string GetDescriptiveGrade(double grade);
        void PrintGrades();
        void PrintSubjects();
        void StudentValidation(string[] studentNames, string studentName);
    }
}
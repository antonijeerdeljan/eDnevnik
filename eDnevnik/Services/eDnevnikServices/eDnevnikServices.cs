using eDnevnik.Model;
using eDnevnik.Services.GradeServices;
using eDnevnik.Services.StudentServices;
using eDnevnik.Services.SubjectServices;
using eDnevnik.Services.ValidatorService;

namespace eDnevnik.Services.eDnevnikServices
{
    public class eDnevnikServices : IeDnevnikServices
    {

        public IValidator _validator { get; set; }
        public List<Student> students { get; set; }
        public List<Grade> grades { get; set; }
        public List<Subject> subjects { get; set; }

        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly IGradeService _gradeService;

        public eDnevnikServices(List<Student> Students, List<Grade> Grades, List<Subject> Subjects, IValidator validator, IStudentService studentService, ISubjectService subjectService, IGradeService gradeService)
        {
            students = Students;
            grades = Grades;
            subjects = Subjects;
            _validator = validator;
            _studentService = studentService;
            _subjectService = subjectService;
            _gradeService = gradeService;
        }

        public void PrintSubjects()
        {
            _subjectService.PrintSubjects(subjects);
        }

        public void AddStudents()
        {
            students = _studentService.AddStudents(students, _validator);
        }

        public void SaveGrade(string[] nameParts, string subject, int grade)
        {

            grades = _gradeService.SaveGrade(nameParts, subject, grade, grades, students, subjects);
        }

        public void AddGrade()
        {
            grades = _gradeService.AddGrade(_validator, grades, students, subjects);

        }

        public Student FindStudent(string[] nameParts)
        {
            return _studentService.FindStudent(students, nameParts);
        }

        public Grade CheckForAnyGrades(int id)
        {
            return _gradeService.CheckForAnyGrades(id, grades);
        }

        public void PrintGrades()
        {
            _gradeService.PrintGrades(_studentService, students, grades, subjects);
        }


    }
}

using eDnevnik.DI;
using eDnevnik.Model;
using eDnevnik.Repository.GradeRepository;
using eDnevnik.Repository.StudentRepository;
using eDnevnik.Repository.SubjectRepository.SubjectRepository;
using eDnevnik.Services;

class Program
{
   

    public static void Main(string[] args)
    {
        IStudentRepository studentRepository = Factory.StudentRepository();
        List<Student> students = studentRepository.ReturnStudents();

        ISubjectRepository subjectRepo = Factory.SubjectRepository();
        List<Subject> subjects = subjectRepo.ReturnSubjects();

        IGradeRepository gradeRepository = Factory.GradeRepository();
        List<Grade> grades = gradeRepository.ReturnGrades();

        eDnevnikServices services = new eDnevnikServices(students,grades,subjects);


        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Print all subjects");
            Console.WriteLine("2. Add new student(s)");
            Console.WriteLine("3. Enter the new grade for the desired student and the desired subject");
            Console.WriteLine("4. Print all grades for all subjects for the desired student and average for each subject");
            Console.WriteLine("5. EXIT");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    services.PrintSubjects();
                    break;
                case 2:
                    services.AddStudents();
                    break;
                case 3:
                    services.AddGrade();
                    break;
                case 4:
                    services.PrintGrades();
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again");
                    break;
            }

            Console.WriteLine();
        }

    }
}

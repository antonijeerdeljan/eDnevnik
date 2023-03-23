using eDnevnik.DI;
using eDnevnik.Model;
using eDnevnik.Repository.GradeRepository;
using eDnevnik.Repository.StudentRepository;
using eDnevnik.Repository.SubjectRepository;
using eDnevnik.Repository.SubjectRepository.SubjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services
{
    public class eDnevnikServices : IeDnevnikServices
    {

        public List<Student> students { get; set; }
        public List<Grade> grades { get; set; }
        public List<Subject> subjects { get; set; }



        public eDnevnikServices(List<Student> Students, List<Grade> Grades, List<Subject> Subjects)
        {
            students = Students;
            grades = Grades;
            subjects = Subjects;
        }
        public void PrintSubjects()
        {
            Console.WriteLine("List of subjects:");
            foreach (Subject subject in subjects)
            {
                Console.WriteLine(subject.ToString());
            }
        }

        public void StudentValidation(string[] studentNames, string studentName)
        {
            int i = 0;
            string[] nameparts = studentNames[i].Split(" ");
            if (students.Where(s => s.Name == nameparts[0]).Where(s => s.Surname == nameparts[1]).FirstOrDefault() != null)
            {
                Console.WriteLine($"Error: {studentName} already exists.");
                return;
            }

            if (studentName.Contains(" "))
            {
                string[] nameParts = studentName.Split(" ");
                if (nameParts.Length == 2)
                {
                    students.Add(new Student { Id = students[students.Count - 1].Id + 1, Name = nameParts[0], Surname = nameParts[1] });
                    Console.WriteLine($"{studentName} successfully added.");
                }
                else
                {
                    Console.WriteLine($"Error: Invalid name for {studentName}. Only first and last name are allowed.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Invalid name for {studentName}. First and last name must be separated by a space.");
            }
            i++;
        }

        public void AddStudents()
        {
            Console.WriteLine("Enter the name(s) of the student(s) separated by comma + space :");
            string[] studentNames = Console.ReadLine().Split(", ");

            foreach (string studentName in studentNames)
            {
                StudentValidation(studentNames, studentName);
            }
        }

        public bool CheckIfStudentExist(string studentName, string[] nameParts)
        {
            if (students.Where(s => s.Name == nameParts[0]).Where(s => s.Surname == nameParts[1]).FirstOrDefault() == null)
                return false;
            return true;
        }

        public bool CheckIfSubjectExist(string subject)
        {
            if (subjects.Where(s => s.Name.Contains(subject)).FirstOrDefault() == null)
                return false;
            return true;
        }

        public void AddGrade()
        {
            Console.WriteLine("Enter the name of the student:");
            string studentName = Console.ReadLine();
            string[] nameParts = studentName.Split(" ");

            if (CheckIfStudentExist(studentName, nameParts) == false)
            {
                Console.WriteLine($"Error: Student {studentName} is not in the system.");
                return;
            }

            Console.WriteLine("Enter the subject:");
            string subject = Console.ReadLine();

            if (CheckIfSubjectExist(subject) == false)
            {
                Console.WriteLine($"Error: Subject {subject} is not in the system.");
                return;
            }

            Console.WriteLine("Enter the grade:");
            int grade;
            bool validGrade = int.TryParse(Console.ReadLine(), out grade);

            if (!validGrade || grade < 1 || grade > 5)
            {
                Console.WriteLine("Error: Invalid grade. Grade must be a whole number between 1 and 5.");
                return;
            }

            Grade gradeToSave = new Grade();
            gradeToSave.Id = grades[grades.Count - 1].Id + 1;
            gradeToSave.StudentId = students.Where(s => s.Name == nameParts[0]).Where(s => s.Surname == nameParts[1]).FirstOrDefault().Id;
            gradeToSave.SubjectId = subjects.Where(s => s.Name == subject).FirstOrDefault().Id;
            gradeToSave.GradeValue = grade;

            grades.Add(gradeToSave);

            Console.WriteLine($"Grade {grade} added for {studentName} in {subject}.");

        }

        public void PrintGrades()
        {
            Console.WriteLine("Enter the name of the student:");
            string studentName = Console.ReadLine();
            string[] nameParts = studentName.Split(" ");
            Student student = students.Where(s => s.Name == nameParts[0]).Where(s => s.Surname == nameParts[1]).FirstOrDefault();
            Grade grade = grades.Where(g => g.StudentId == student.Id).FirstOrDefault(); //Check if anything exist

            if (student == null)
            {
                Console.WriteLine($"Error: Student {studentName} is not in the system.");
                return;
            }

            if (grade == null)
            {
                Console.WriteLine($"Student {studentName} does not have any grades.");
                return;
            }

            foreach (Subject subject in subjects)
            {
                Console.Write($"{subject.Name}: ");

                List<Grade> subjectGrades = grades.Where(g => g.StudentId == student.Id && g.SubjectId == subject.Id).ToList();
                if (subjectGrades.Count == 0)
                {
                    Console.Write("No grade\n");
                }
                else
                {
                    Console.Write(string.Join(", ", subjectGrades.Select(g => g.GradeValue)));

                    decimal averageGrade = (decimal)subjectGrades.Average(g => g.GradeValue);
                    Console.Write($"Average grade: [{averageGrade:N1}], "); //N1 for printing .0 on whole numbers like 3.0

                    string descriptiveGrade = GetDescriptiveGrade((double)averageGrade);

                    Console.WriteLine(descriptiveGrade);
                }
            }
        }

        public string GetDescriptiveGrade(double grade)
        {
            if (grade < 2.5)
            {
                return "Insufficient";
            }
            else if (grade < 3.5)
            {
                return "Satisfactory";
            }
            else if (grade < 4.5)
            {
                return "Good";
            }
            else if (grade < 5.0)
            {
                return "Very good";
            }
            else
            {
                return "Excellent";
            }
        }
    }
}

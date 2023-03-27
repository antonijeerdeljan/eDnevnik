using eDnevnik.Model;
using eDnevnik.Services.StudentServices;
using eDnevnik.Services.ValidatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.GradeServices
{
    public class GradeService : IGradeService
    {

        public List<Grade> SaveGrade(string[] nameParts, string subject, int grade, List<Grade> grades, List<Student> students, List<Subject> subjects)
        {
            Grade gradeToSave = new Grade();
            gradeToSave.Id = grades[grades.Count - 1].Id + 1;
            gradeToSave.StudentId = students.Where(s => s.Name == nameParts[0]).Where(s => s.Surname == nameParts[1]).FirstOrDefault().Id;
            gradeToSave.SubjectId = subjects.Where(s => s.Name == subject).FirstOrDefault().Id;
            gradeToSave.GradeValue = grade;
            grades.Add(gradeToSave);
            return grades;
        }

        public List<Grade> AddGrade(IValidator _validator, List<Grade> grades, List<Student> students, List<Subject> subjects)
        {
            Console.WriteLine("Enter the name of the student:");
            string studentName = Console.ReadLine();
            string[] nameParts = studentName.Split(" ");

            if (_validator.CheckIfStudentExist(studentName, nameParts) == false)
            {
                Console.WriteLine($"Error: Student {studentName} is not in the system.");
                return null;
            }

            Console.WriteLine("Enter the subject:");
            string subject = Console.ReadLine();

            if (_validator.CheckIfSubjectExist(subject) == false)
            {
                Console.WriteLine($"Error: Subject {subject} is not in the system.");
                return null;
            }

            Console.WriteLine("Enter the grade:");
            int grade;
            bool validGrade = int.TryParse(Console.ReadLine(), out grade);

            if (!validGrade || grade < 1 || grade > 5)
            {
                Console.WriteLine("Error: Invalid grade. Grade must be a whole number between 1 and 5.");
                return null;
            }

            List<Grade> gradesToReturn = SaveGrade(nameParts, subject, grade, grades, students, subjects);


            Console.WriteLine($"Grade {grade} added for {studentName} in {subject}.");

            return gradesToReturn;

        }

        public Grade CheckForAnyGrades(int id, List<Grade> grades)
        {
            return grades.Where(g => g.StudentId == id).FirstOrDefault();
        }

        public void PrintGrades(IStudentService studentService, List<Student> students, List<Grade> grades, List<Subject> subjects)
        {
            Console.WriteLine("Enter the name of the student:");
            string studentName = Console.ReadLine();
            string[] nameParts = studentName.Split(" ");
            Student student = studentService.FindStudent(students, nameParts);
            Grade grade = CheckForAnyGrades(student.Id, grades); //Check if anything exist

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

            PrintSubjectsAndGrades(student, subjects, grades);
        }

        public void PrintSubjectsAndGrades(Student student, List<Subject> subjects, List<Grade> grades)
        {
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

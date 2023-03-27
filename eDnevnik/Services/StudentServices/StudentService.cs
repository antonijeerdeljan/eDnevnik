using eDnevnik.Model;
using eDnevnik.Services.ValidatorService;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.StudentServices
{
    public class StudentService : IStudentService
    {

        public List<Student> AddStudents(List<Student> students, IValidator _validator)
        {
            Console.WriteLine("Enter the name(s) of the student(s) separated by comma + space :");
            string[] studentNames = Console.ReadLine().Split(", ");
            students = _validator.StudentValidationOnCreating(studentNames);
            return students;

        }

        public Student FindStudent(List<Student> students, string[] nameParts)
        {
            return students.Where(s => s.Name == nameParts[0]).Where(s => s.Surname == nameParts[1]).FirstOrDefault();
        }


    }
}

using eDnevnik.Model;

namespace eDnevnik.Services.ValidatorService
{
    public class Validator : IValidator
    {
        public List<Student> _students;
        public List<Subject> _subjects;
        public Validator(List<Student> students, List<Subject> subjects)
        {
            _students = students;
            _subjects = subjects;
        }


        public List<Student> StudentValidationOnCreating(string[] studentNames)
        {
            //counter for multiple Students on start
            for (int i = 0; i < studentNames.Length; i++)
            {
                string[] nameparts = studentNames[i].Split(" ");
                if (_students.Where(s => s.Name == nameparts[0]).Where(s => s.Surname == nameparts[1]).FirstOrDefault() != null)
                {
                    Console.WriteLine($"Error: {nameparts[0]} already exists.");
                    return null;
                }

                if (studentNames[i].Contains(" "))
                {
                    string[] nameParts = studentNames[i].Split(" ");
                    if (nameParts.Length == 2)
                    {
                        _students.Add(new Student { Id = _students[_students.Count - 1].Id + 1, Name = nameParts[0], Surname = nameParts[1] });
                        Console.WriteLine($"{nameparts[0]} successfully added.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: Invalid name for {nameparts[0]}. Only first and last name are allowed.");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: Invalid name for {nameparts[0]}. First and last name must be separated by a space.");
                }

            }
            return _students;
        }

        public bool CheckIfStudentExist(string studentName, string[] nameParts)
        {
            if (_students.Where(s => s.Name == nameParts[0]).Where(s => s.Surname == nameParts[1]).FirstOrDefault() == null)
                return false;
            return true;
        }

        public bool CheckIfSubjectExist(string subject)
        {
            if (_subjects.Where(s => s.Name.Contains(subject)).FirstOrDefault() == null)
                return false;
            return true;
        }


    }
}

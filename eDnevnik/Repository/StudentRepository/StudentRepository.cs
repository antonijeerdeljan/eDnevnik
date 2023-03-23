using eDnevnik.Model;

namespace eDnevnik.Repository.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        public List<Student> ReturnStudents()
        {
            List<Student> students = new List<Student>()
            {
                new Student() { Id = 1, Name = "Milos", Surname = "Ostojic" },
                new Student() { Id = 2, Name = "Nikola", Surname = "Markov" },
                new Student() { Id = 3, Name = "Marko", Surname = "Simic" },
                new Student() { Id = 4, Name = "Ivan", Surname = "Mihajlov" },
                new Student() { Id = 5, Name = "Filip", Surname = "Vukas" },
                new Student() { Id = 6, Name = "David", Surname = "Sandor" },
                new Student() { Id = 7, Name = "Antonije", Surname = "Erdeljan" },
                new Student() { Id = 8, Name = "Luka", Surname = "Radic" },
                new Student() { Id = 9, Name = "Stefan", Surname = "Djurdjevic" },
                new Student() { Id = 10, Name = "Dusan", Surname = "Runjevac" }
            };

            return students;

        }

    }
}

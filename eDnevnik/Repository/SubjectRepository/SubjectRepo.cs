using eDnevnik.Model;
using eDnevnik.Repository.SubjectRepository.SubjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Repository.SubjectRepository
{
    public class SubjectRepo : ISubjectRepository
    {
        public List<Subject> ReturnSubjects()
        {
            List<Subject> subjects = new List<Subject>()
        {
            new Subject() { Id = 1, Name = "Matematika" },
            new Subject() { Id = 2, Name = "Fizika" },
            new Subject() { Id = 3, Name = "Engleski" },
            new Subject() { Id = 4, Name = "Istorija" },
            new Subject() { Id = 5, Name = "Geografija" },
            new Subject() { Id = 6, Name = "Likovno" },
            new Subject() { Id = 7, Name = "Muzicko" },
            new Subject() { Id = 8, Name = "Fizicko" },
            new Subject() { Id = 9, Name = "Informatika" },
            new Subject() { Id = 10, Name = "Nemacki" }
        };

            return subjects;
        }
    }

}

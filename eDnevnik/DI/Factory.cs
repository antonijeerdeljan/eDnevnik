using eDnevnik.Repository.GradeRepository;
using eDnevnik.Repository.StudentRepository;
using eDnevnik.Repository.SubjectRepository;
using eDnevnik.Repository.SubjectRepository.SubjectRepository;
using eDnevnik.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.DI
{
    public static class Factory
    {
        public static IGradeRepository GradeRepository()
        {
            return new GradeRepository();
        }

        public static ISubjectRepository SubjectRepository()
        {
            return new SubjectRepo();
        }

        public static IStudentRepository StudentRepository()
        {
            return new StudentRepository();
        }

        
        
    }
}

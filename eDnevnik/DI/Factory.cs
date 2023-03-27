using eDnevnik.Repository.GradeRepository;
using eDnevnik.Repository.StudentRepository;
using eDnevnik.Repository.SubjectRepository;
using eDnevnik.Repository.SubjectRepository.SubjectRepository;
using eDnevnik.Services;
using eDnevnik.Services.eDnevnikServices;
using eDnevnik.Services.GradeServices;
using eDnevnik.Services.StudentServices;
using eDnevnik.Services.SubjectServices;
using eDnevnik.Services.ValidatorService;
using System.Net.Http.Headers;

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

        public static IValidator Validator()
        {
            return new Validator(StudentRepository().ReturnStudents(),SubjectRepository().ReturnSubjects());
        }

        public static IeDnevnikServices EDnevnikServices()
        {
            return new eDnevnikServices(StudentRepository().ReturnStudents(),GradeRepository().ReturnGrades(),SubjectRepository().ReturnSubjects(),Validator(),StudentService(),SubjectService(),GradeService());
        }

        public static IStudentService StudentService()
        {
            return new StudentService();
        }

        public static ISubjectService SubjectService()
        {
            return new SubjectService();
        }

        public static IGradeService GradeService()
        {
            return new GradeService();
        }



    }
}

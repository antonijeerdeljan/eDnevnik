using eDnevnik.Model;
using eDnevnik.Serializer;

namespace eDnevnik.Repository.GradeRepository
{
    public class GradeRepositoryCSV 
    {
        private const string FilePath = "../../../Resources/Data/grades.txt";

        private readonly Serializer<Grade> _serializer;

        private readonly List<Grade> _grades;

        public GradeRepositoryCSV()
        {
            _serializer = new Serializer<Grade>();
            _grades = _serializer.FromCSV(FilePath);
        }

        public Grade Save(Grade grade)
        {
            grade.Id = NextId();
            _grades.Add(grade);
            _serializer.ToCSV(FilePath, _grades);
            return grade;

        }

        public int NextId()
        {
            List<Grade> grades = GetAll();
            if(grades.Count != 0)
            {
                int id = grades[grades.Count - 1].Id + 1;
                return id;
            }else
                return 1; 
            
        }


        public List<Grade> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
    }

}

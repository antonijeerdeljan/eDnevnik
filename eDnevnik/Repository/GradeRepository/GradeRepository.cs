using eDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Repository.GradeRepository
{
    public class GradeRepository : IGradeRepository
    {
        public List<Grade> ReturnGrades()
        {
            List<Grade> grades = new List<Grade>()
        {
            new Grade() { Id = 1, SubjectId = 1, StudentId = 1 ,GradeValue = 5},
            new Grade() { Id = 2, SubjectId = 2, StudentId = 1 ,GradeValue = 2},
            new Grade() { Id = 3, SubjectId = 3, StudentId = 2 ,GradeValue = 4},
            new Grade() { Id = 4, SubjectId = 4, StudentId = 3 ,GradeValue = 1},
            new Grade() { Id = 5, SubjectId = 5, StudentId = 3 ,GradeValue = 5},
            new Grade() { Id = 6, SubjectId = 6, StudentId = 4 ,GradeValue = 3},
            new Grade() { Id = 7, SubjectId = 7, StudentId = 4 ,GradeValue = 3},
            new Grade() { Id = 8, SubjectId = 1, StudentId = 7 ,GradeValue = 1},
            new Grade() { Id = 9, SubjectId = 1, StudentId = 7 ,GradeValue = 5},
            new Grade() { Id = 10, SubjectId = 10, StudentId = 10 ,GradeValue = 4}
        };

            return grades;
        }
    }
}

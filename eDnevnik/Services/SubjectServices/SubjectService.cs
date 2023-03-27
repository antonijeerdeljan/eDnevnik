using eDnevnik.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDnevnik.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {

        public void PrintSubjects(List<Subject> subjects)
        {
            Console.WriteLine("List of subjects:");
            foreach (Subject subject in subjects)
            {
                Console.WriteLine(subject.ToString());
            }
        }



    }
}

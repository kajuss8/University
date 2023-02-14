using System;
using System.Collections.Generic;
using System.Linq;
using University.Entity;

namespace University.Repository
{
    public class SubjectRepository
    {
        public List<Subject> Retrieve()
        {
            using UniversityContext universityContext = new UniversityContext();
            return universityContext.Subjects.ToList();
        }

        public Subject Retrieve(int subjectId)
        {
            using UniversityContext universityContext = new UniversityContext();
            return universityContext.Subjects.Where(d => d.Id == subjectId).FirstOrDefault();
        }

        public Subject CreateSubject()
        {
            Console.WriteLine("Write subject name: ");
            string name = Console.ReadLine();
            return new Subject(name);
        }
    }
}

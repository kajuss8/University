using System;
using System.Collections.Generic;
using System.Linq;
using University.Entity;

namespace University.Repository
{
    public class StudentRepository
    {
        public List<Student> RetrieveAllStudents()
        {
            using UniversityContext universityContext = new UniversityContext();
            return universityContext.Students.ToList();
        }

        public Student Retrieve(int studentId)
        {
            using UniversityContext universityContext = new UniversityContext();
            return universityContext.Students.Where(d => d.Id == studentId).FirstOrDefault();
        }

        public Student CreateStudent()
        {
            Console.WriteLine("Write student name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nWrite surname: ");
            string surname = Console.ReadLine();
            return new Student(name, surname);
        }
    }
}

using System;
using System.Collections.Generic;

namespace University.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? DepartmentId { get; set; }
        public Department Departments { get; set; }
        public List<StudentSubject> studentSubjects { get; set; }

        public Student(string name, string surname)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name can't be emty");
            }
            if (string.IsNullOrEmpty(surname))
            {
                throw new ArgumentNullException("surname can't be emty");
            }
            Name = name;
            Surname = surname;
        }
    }
}

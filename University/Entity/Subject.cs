using System;
using System.Collections.Generic;

namespace University.Entity
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DepartmentSubject> departmentSubjects { get; set; }
        public List<StudentSubject> studentSubjects { get; set; }
        public Subject(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name can't be emty");
            }
            Name = name;
        }
    }
}

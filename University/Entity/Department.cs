using System;
using System.Collections.Generic;

namespace University.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Student> Students { get; set; }
        public List<DepartmentSubject> departmentSubjects { get; set; }
        public Department(string name, string location)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name can't be emty");
            }
            if (string.IsNullOrEmpty(location))
            {
                throw new ArgumentNullException("location can't be emty");
            }
            Name = name;
            Location = location;
        }
    }
}

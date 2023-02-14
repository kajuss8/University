using System;
using System.Collections.Generic;
using System.Linq;
using University.Entity;

namespace University.Repository
{
    public class DepartmentRepository
    {
        public List<Department> Retrieve()
        {
            using UniversityContext universityContext = new UniversityContext();
            return universityContext.Departments.ToList();
        }

        public Department Retrieve(int departmentId)
        {
            using UniversityContext universityContext = new UniversityContext();
            return universityContext.Departments.Where(d => d.Id == departmentId).FirstOrDefault();
        }

        public Department CreateDepartment()
        {

            Console.WriteLine("Write department name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nWrite location: ");
            string location = Console.ReadLine();
            return new Department(name, location);
        }
    }
}
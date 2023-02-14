using System;
using System.Linq;
using University.Entity;
using University.Interface;
using University.Repository;

namespace University.Examfunctions
{
    public class ConsoleResult : IConsoleResult
    {
        public DepartmentRepository DepartmentRepository { get; set; }
        public StudentRepository StudentRepository { get; set; }
        public SubjectRepository SubjectRepository { get; set; }
        public ConsoleResult()
        {
            DepartmentRepository = new DepartmentRepository();
            StudentRepository = new StudentRepository();
            SubjectRepository = new SubjectRepository();
        }

        public void PrintDepartmentStudent()
        {
            using UniversityContext universityContext = new UniversityContext();
            while(true)
            {
                Console.WriteLine("Choose department ID:");
                universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"{d.Id} {d.Name} {d.Location}"));
                int userChosenId = Convert.ToInt32(Console.ReadLine());
                Department department = DepartmentRepository.Retrieve(userChosenId);
                if (department != null)
                {
                    universityContext.Students.Where(s => s.Departments == department).ToList()
                        .ForEach(s => Console.WriteLine($"ID: {s.Id} Name: {s.Name} Surname: {s.Surname} DepartmentId: {s.DepartmentId}"));
                    Console.WriteLine("Search again? [y,n]");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        continue;
                    }
                    else if (yesOrNo == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("you chose not existing answer");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Chosen wrong ID");
                }
            }
        }

        public void PrintDepartmentSubject()
        {
            using UniversityContext universityContext = new UniversityContext();
            while (true)
            {
                Console.WriteLine("Choose department ID:");
                universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"{d.Id} {d.Name} {d.Location}"));
                int userChosenId = Convert.ToInt32(Console.ReadLine());
                Department department = universityContext.Departments.FirstOrDefault(d => d.Id == userChosenId);
                if (department != null)
                {
                    DepartmentSubject departmentSubject = new DepartmentSubject();
                    universityContext.Departments.Where(d => d == department).SelectMany(d => d.departmentSubjects).Select(ds => ds.Subject).ToList()
                        .ForEach(s => Console.WriteLine($"ID: {s.Id} Name: {s.Name}"));
                    Console.WriteLine("Search again? [y,n]");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        continue;
                    }
                    else if (yesOrNo == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("you chose not existing answer");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Chosen wrong ID");
                }
            }
        }

        public void PrintSubjectConnectedToStudent()
        {
            using UniversityContext universityContext = new UniversityContext();
            while (true)
            {
                Console.WriteLine("Choose student ID:");
                universityContext.Students.ToList().ForEach(d => Console.WriteLine($"{d.Id} {d.Name} {d.Surname}"));
                int userChosenId = Convert.ToInt32(Console.ReadLine());
                Student student = universityContext.Students.FirstOrDefault(d => d.Id == userChosenId);
                if (student != null)
                {
                    DepartmentSubject departmentSubject = new DepartmentSubject();
                    universityContext.Students.Where(d => d == student).SelectMany(d => d.studentSubjects).Select(ds => ds.Subject).ToList()
                        .ForEach(s => Console.WriteLine($"ID: {s.Id} Name: {s.Name}"));
                    Console.WriteLine("Search again? [y,n]");
                    string yesOrNo = Console.ReadLine();
                    if (yesOrNo == "y")
                    {
                        continue;
                    }
                    else if (yesOrNo == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("you chose not existing answer");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Chosen wrong ID");
                }
            }
        }
    }
}

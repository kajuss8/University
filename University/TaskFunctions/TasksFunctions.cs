using System;
using System.Linq;
using University.Entity;
using University.Interface;
using University.Repository;

namespace University.TaskFunctions
{
    public class TasksFunctions : ITaskFunctions
    {
        public DepartmentRepository DepartmentRepository { get; set; }
        public StudentRepository StudentRepository { get; set; }
        public SubjectRepository SubjectRepository { get; set; }
        public TasksFunctions()
        {
            DepartmentRepository = new DepartmentRepository();
            StudentRepository = new StudentRepository();
            SubjectRepository = new SubjectRepository();
        }

        public void AddStudentsAndSubjectsToNewDepartment()
        {
            using UniversityContext universityContext = new UniversityContext();
            while(true)
            {
                Department department = DepartmentRepository.CreateDepartment();
                Console.WriteLine("Add student to department? [y/n]");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    while(true)
                    {
                        Student student = StudentRepository.CreateStudent();
                        department.Students?.Add(student);
                        student.Departments = department;
                        universityContext.Students?.Add(student);
                        Console.WriteLine("One more? [y/n]");
                        choice = Console.ReadLine();
                        if(choice == "y")
                        {
                            continue;
                        }
                        else if(choice == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("you chose not existing answer");
                            break;
                        }
                    }
                }
                Console.WriteLine("Add subject to department? [y/n]");
                choice = Console.ReadLine();
                if (choice == "y")
                {
                    while(true)
                    {
                        Subject subject = SubjectRepository.CreateSubject();
                        DepartmentSubject departmentSubject = new DepartmentSubject();
                        departmentSubject.Subject = subject;
                        departmentSubject.Department = department;
                        universityContext.DepartmentSubjects.Add(departmentSubject);
                        Console.WriteLine("One more? [y/n]");
                        choice = Console.ReadLine();
                        if (choice == "y")
                        {
                            continue;
                        }
                        else if (choice == "n")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("you chose not existing answer");
                            break;
                        }
                    }
                }
                universityContext.Departments?.Add(department);
                universityContext.SaveChanges();
                Console.WriteLine("want to create another department? [y/n]");
                choice = Console.ReadLine();
                if (choice == "y")
                {
                    continue;
                }
                else if (choice == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("you chose not existing answer");
                    break;
                }
            }
        }

        public void AddStudentOrSubjectToExistingDepartment()
        {
            using UniversityContext universityContext = new UniversityContext();
            while(true)
            {
                Console.WriteLine("Add student or subject to department: 1-student, 2-subject");
                string choice = Console.ReadLine();
                if(choice == "1")
                {
                    while(true)
                    {
                        Student student = StudentRepository.CreateStudent();
                        Console.WriteLine("Write ID of department you want to put student");
                        universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name}"));
                        int userChosenId = Convert.ToInt32(Console.ReadLine());
                        Department department = DepartmentRepository.Retrieve(userChosenId);
                        if (department != null)
                        {
                            universityContext.Students.Where(s => s.Departments == department).ToList().Add(student);
                            universityContext.SaveChanges();
                            Console.WriteLine("Add another one? [y,n]");
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
                            Console.WriteLine("you chose wrong ID");
                        }
                    }    
                }

                else if(choice == "2")
                {
                    while(true)
                    {
                        Subject subject = SubjectRepository.CreateSubject();
                        Console.WriteLine("Write ID of department you want to put subject");
                        universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name}"));
                        int userChosenId = Convert.ToInt32(Console.ReadLine());
                        Department department = universityContext.Departments.FirstOrDefault(d => d.Id == userChosenId);
                        if (department != null)
                        {
                            DepartmentSubject departmentSubject = new DepartmentSubject();
                            departmentSubject.Department = department;
                            departmentSubject.Subject = subject;
                            universityContext.DepartmentSubjects.Add(departmentSubject);
                            universityContext.SaveChanges();
                            Console.WriteLine("Add another one? [y,n]");
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
                            Console.WriteLine("you chose wrong ID");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("you chose not existing answer");
                }
                Console.WriteLine("want to create another department? [y/n]");
                string repeat = Console.ReadLine();
                if (choice == "y")
                {
                    continue;
                }
                else if (choice == "n")
                {
                    break;
                }
            }
        }

        public void CreateSubjectAndAddToExistingDepartment()
        {
            using UniversityContext universityContext = new UniversityContext();
            while(true)
            {
                Subject subject = SubjectRepository.CreateSubject();
                Console.WriteLine("Write ID of department you want to put subject");
                universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name}"));
                int userChosenId = Convert.ToInt32(Console.ReadLine());
                Department department = universityContext.Departments.FirstOrDefault(d => d.Id == userChosenId);
                if (department != null)
                {
                    DepartmentSubject departmentSubject = new DepartmentSubject();
                    departmentSubject.Department = department;
                    departmentSubject.Subject = subject;
                    universityContext.DepartmentSubjects.Add(departmentSubject);
                    universityContext.SaveChanges();
                    Console.WriteLine("Add another one? [y,n]");
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
                    Console.WriteLine("you chose wrong ID");
                }
            }    
        }

        public void CreateStudentAddToExistingDepartmentAndAddSubject()
        {
            using UniversityContext universityContext = new UniversityContext();
            while(true)
            {
                Student student = StudentRepository.CreateStudent();
                Console.WriteLine("Write ID of department you want to put student");
                universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name}"));
                int userChosenId = Convert.ToInt32(Console.ReadLine());
                Department department = universityContext.Departments.FirstOrDefault(d => d.Id == userChosenId);
                if (department != null)
                {
                    student.Departments = department;
                    Console.WriteLine("Write ID of subject you want to give to student");
                    universityContext.Subjects.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name}"));
                    userChosenId = Convert.ToInt32(Console.ReadLine());
                    Subject subject = universityContext.Subjects.FirstOrDefault(d => d.Id == userChosenId);
                    if (subject != null)
                    {
                        StudentSubject studentSubject = new StudentSubject();
                        studentSubject.Student = student;
                        studentSubject.Subject = subject;
                        universityContext.StudentSubject.Add(studentSubject);
                        universityContext.SaveChanges();
                        Console.WriteLine("Create another one student? [y,n]");
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
                        Console.WriteLine("you chose wrong ID");
                    }
                }
                else
                {
                    Console.WriteLine("you chose wrong ID");
                }
            }
        }

        public void ChangeStudentDepartment()
        {
            using UniversityContext universityContext = new UniversityContext();
            while(true)
            {
                Console.WriteLine("Choose student by his ID");
                universityContext.Students.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name} - Surname: {d.Surname}"));
                int userChosenStudentId = Convert.ToInt32(Console.ReadLine());
                Student student = universityContext.Students.FirstOrDefault(d => d.Id == userChosenStudentId);
                if (student != null)
                {
                    Console.WriteLine("Write ID of department you want to put student");
                    universityContext.Departments.ToList().ForEach(d => Console.WriteLine($"ID: {d.Id} - Name: {d.Name}"));
                    int userChosenDepartmentId = Convert.ToInt32(Console.ReadLine());
                    Department department = universityContext.Departments.FirstOrDefault(d => d.Id == userChosenDepartmentId);
                    if (department != null)
                    {
                        student.Departments = department;
                        universityContext.Departments.Where(d => d == department).SelectMany(d => d.Students).ToList().Add(student);
                        universityContext.SaveChanges();
                        Console.WriteLine("change another student department? [y,n]");
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
                        Console.WriteLine("you chose wrong ID");
                    }
                }
                else
                {
                    Console.WriteLine("you chose wrong ID");
                }
            }
        }
    }
}

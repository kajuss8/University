using System.IO;
using System.Linq;
using University.Interface;
using University.Repository;

namespace University.Report
{
    public class ReportResult : IReport
    {
        public DepartmentRepository DepartmentRepository { get; set; }
        public StudentRepository StudentRepository { get; set; }
        public SubjectRepository SubjectRepository { get; set; }
        public ReportResult()
        {
            DepartmentRepository = new DepartmentRepository();
            StudentRepository = new StudentRepository();
            SubjectRepository = new SubjectRepository();
        }

        public void AddResultToTxtFile()
        {
            using UniversityContext universityContext = new UniversityContext();
            string DbResult = @"C:\Users\37067\OneDrive\Desktop\C sharp basic\University\University\ResultTxtFile\ResultFile.txt";
            File.WriteAllText(DbResult, "");
            File.AppendAllText(DbResult, $"Department:\n");
            universityContext.Departments.ToList().ForEach(d => File.AppendAllText(DbResult, $"[ID:{d.Id}] [Name:{d.Name}] [Location:{d.Location}]\n"));
            File.AppendAllText(DbResult, $"\nDepartmenSubject:\n");
            universityContext.DepartmentSubjects.ToList().ForEach(ds => File.AppendAllText(DbResult, $"[DepartmentID:{ds.DepartmentId}] [SubjectID:{ds.SubjectId}]\n"));
            File.AppendAllText(DbResult, $"\nSubject:\n");
            universityContext.Subjects.ToList().ForEach(s => File.AppendAllText(DbResult, $"[ID:{s.Id}] [Name:{s.Name}]\n"));
            File.AppendAllText(DbResult, $"\nStudentSubject:\n");
            universityContext.StudentSubject.ToList().ForEach(ds => File.AppendAllText(DbResult, $"[StudentId:{ds.StudentId}] [SubjectID:{ds.SubjectId}]\n"));
            File.AppendAllText(DbResult, $"\nStudent:\n");
            universityContext.Students.ToList().ForEach(s => File.AppendAllText(DbResult, $"[ID:{s.Id}] [Name:{s.Name}] [Surname:{s.Surname}]\n"));
        }
    }
}

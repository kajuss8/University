using University.Examfunctions;
using University.Report;
using University.TaskFunctions;

namespace University
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TasksFunctions tasksFunctions = new TasksFunctions();
            ConsoleResult consoleResult = new ConsoleResult();
            ReportResult reportResult = new ReportResult();
            //tasksFunctions.CreateSubjectAndAddToExistingDepartment();
            //consoleResult.PrintSubjectConnectedToStudent();
            reportResult.AddResultToTxtFile();
        }
    }
}

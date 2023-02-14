
namespace University.Entity
{
    public class DepartmentSubject
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }
        public Department Department { get; set; }
        public Subject Subject { get; set; }
    }
}

using BooleanşMvcApp.Tables;

namespace BooleanşMvcApp.Models
{
    public class StudentDetailModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string GroupName { get; set; }
        public StudentDetail StudentDetail { get; set; }
    }
}

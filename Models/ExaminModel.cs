using BooleanşMvcApp.Tables;

namespace BooleanşMvcApp.Models
{
    public class ExaminModel
    {
        public int Id { get; set; }
        public int Result { get; set; }
        public StudentModel Student { get; set; }
        public Subject Subject { get; set; }
    }
}

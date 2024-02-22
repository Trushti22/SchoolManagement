namespace SchoolManagement.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public string RoomNumber { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}

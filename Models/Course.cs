namespace SchoolManagement.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }
    }
}

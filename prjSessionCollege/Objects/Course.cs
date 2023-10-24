namespace prjSessionCollege.Objects
{
    public class Course
    {
        public int id { get; set; }
        public int fkDepartmenetId { get; set; }
        public string description { get; set; }
        public string details { get; set; }
    }
}

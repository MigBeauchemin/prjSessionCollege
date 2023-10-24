namespace prjSessionCollege.Objects
{
    public class CourseSemesterStudent
    {
        public int id { get; set; }
        public int fkStudentId { get; set; }
        public string? studentFirstName { get; set; }
        public string? studentLastName { get; set; }
        public string? grade { get; set; }
    }
}

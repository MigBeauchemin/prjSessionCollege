using prjSessionCollege.Objects;

namespace prjSessionCollege.JSON
{
    public class ResponseJSONCourseSemesters
    {
        public string status { get; set; }
        public string message { get; set; }

        public List<CourseSemester> data { get; set; }

        public ResponseJSONCourseSemesters()
        {

            this.status = "failed";
            this.message = "unknown error";
            this.data = new List<CourseSemester>();

        }
    }
}

using prjSessionCollege.Objects;

namespace prjSessionCollege.JSON
{
    public class ResponseJSONCourseSemesterStudent
    {
        public string status { get; set; }
        public string message { get; set; }

        public List<CourseSemesterStudent> data { get; set; }

        public ResponseJSONCourseSemesterStudent()
        {

            this.status = "failed";
            this.message = "unknown error";
            this.data = new List<CourseSemesterStudent>();

        }
    }
}

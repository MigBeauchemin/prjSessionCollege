using prjSessionCollege.Objects;

namespace prjSessionCollege.JSON
{
    public class ResponseJSONPerson
    {
        public string status { get; set; }
        public string message { get; set; }

        public List<Person> data { get; set; }

        public ResponseJSONPerson()
        {

            this.status = "failed";
            this.message = "unknown error";
            this.data = new List<Person>();

        }
    }
}

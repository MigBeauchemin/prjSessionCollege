namespace prjSessionCollege.JSON
{
    public class ResponseJSON
    {
        public string status { get; set; }
        public string message { get; set; }
        public string data { get; set; }

        public ResponseJSON()
        {

            this.status = "failed";
            this.message = "unknown error";
            this.data = "";

        }
    }
}

using prjSessionCollege.Objects;

namespace prjSessionCollege.Models
{
    public class EtudiantsModel
    {
        public List<Person> Students { get; set; }
        public List<CourseSemesterStudent> Grades { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }

    }
}
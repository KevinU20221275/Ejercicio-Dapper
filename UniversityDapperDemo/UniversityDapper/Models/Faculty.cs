namespace UniversityDapper.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public string? FacultyName { get; set; }

        public int UniversityId { get; set; }

        public University? University { get; set; }
    }
}

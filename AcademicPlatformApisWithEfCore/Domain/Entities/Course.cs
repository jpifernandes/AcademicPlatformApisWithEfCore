using System.Collections.Generic;

namespace AcademicPlatformApisWithEfCore.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public double DurationInMinutes { get; set; }
        public IEnumerable<CourseEntry> Entries { get; set; }
    }
}

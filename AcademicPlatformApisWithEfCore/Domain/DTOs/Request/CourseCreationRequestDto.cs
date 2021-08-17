namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Request
{
    public sealed class CourseCreationRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public double DurationInMinutes { get; set; }
    }
}

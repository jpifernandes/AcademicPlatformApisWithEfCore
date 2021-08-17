namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Response
{
    public sealed class CourseResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public double DurationInMinutes { get; set; }
    }
}

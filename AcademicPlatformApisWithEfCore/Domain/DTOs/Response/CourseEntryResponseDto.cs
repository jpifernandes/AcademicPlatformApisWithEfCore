namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Response
{
    public sealed class CourseEntryResponseDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int UserId { get; set; }
    }
}

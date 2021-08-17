namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Request
{
    public sealed class CourseEntryCreationRequestDto
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
    }
}

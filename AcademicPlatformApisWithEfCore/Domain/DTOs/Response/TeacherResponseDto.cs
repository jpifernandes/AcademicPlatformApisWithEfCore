using System;

namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Response
{
    public sealed class TeacherResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredIn { get; set; }
        public bool Enabled { get; set; }
        public string Cpf { get; set; }
        public string CtpsNumber { get; set; }
    }
}

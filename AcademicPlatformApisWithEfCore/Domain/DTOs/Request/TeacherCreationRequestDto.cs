using System;

namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Request
{
    public sealed class TeacherCreationRequestDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredIn { get; set; }
        public bool Enabled { get; set; }
        public string Cpf { get; set; }
        public string CtpsNumber { get; set; }
    }
}

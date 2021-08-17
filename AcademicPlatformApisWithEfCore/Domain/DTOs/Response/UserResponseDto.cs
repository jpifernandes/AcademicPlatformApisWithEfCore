using System;

namespace AcademicPlatformApisWithEfCore.Domain.DTOs.Response
{
    public sealed class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredIn { get; set; }
        public bool Enabled { get; set; }
    }
}

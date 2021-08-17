using System;
using System.Collections.Generic;

namespace AcademicPlatformApisWithEfCore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegisteredIn { get; set; }
        public bool Enabled { get; set; }
        public IEnumerable<CourseEntry> Entries { get; set; }
    }
}

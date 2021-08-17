using System.Collections.Generic;

namespace AcademicPlatformApisWithEfCore.Domain.Entities
{
    public class Teacher : User
    {
        public string Cpf { get; set; }
        public string CtpsNumber { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}

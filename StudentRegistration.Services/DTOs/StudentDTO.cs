using StudentRegistration.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.DTOs
{
    public class StudentDTO
    {
        public Guid IdStudents { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public int IdIdentificationType { get; set; }

        public string DocumentNumber { get; set; } = null!;

        public virtual IdentificationType IdIdentificationTypeNavigation { get; set; } = null!;

        public virtual ICollection<ProgramStudent> ProgramStudents { get; set; } = new List<ProgramStudent>();

        public virtual ICollection<SubjectStudent> SubjectStudents { get; set; } = new List<SubjectStudent>();

        public virtual UsersLogin User { get; set; } = null!;
    }
}

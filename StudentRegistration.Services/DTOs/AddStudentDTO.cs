using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.DTOs
{
    public class AddStudentDTO
    {
        public Guid UserId { get; set; }
        public Guid? IdStudents { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdIdentificationType { get; set; }
        public string DocumentNumber { get; set; }
    }
}

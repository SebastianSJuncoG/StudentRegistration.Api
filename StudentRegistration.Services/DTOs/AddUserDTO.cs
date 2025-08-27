using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.DTOs
{
    public class AddUserDTO
    {
        public Guid? IdUser { get; set; }
        public string UserName { get; set; }
        public string TempPassword { get; set; }
        public int TypeUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int IdIdentificationType { get; set; }
        public string DocumentNumber { get; set; }
    }
}

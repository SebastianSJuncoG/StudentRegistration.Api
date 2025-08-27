using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.DTOs
{
    public class UserDTO
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string? TempPassword { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int BlockingAttempts { get; set; }
        public DateTime? DateLastLogin { get; set; }
        public Boolean Active { get; set; }
    }
}

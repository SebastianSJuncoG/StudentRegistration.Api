using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Models.Responses
{
    public class UserLoginResponse
    {
        public Guid Id_Users { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int BlockingAttempts { get; set; }
        public DateTime? DateLastLogin { get; set; }
        public Boolean Active { get; set; }
        public string? ResultMessage { get; set; }
    }
}

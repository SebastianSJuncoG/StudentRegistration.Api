using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.DTOs
{
    public class AddSubjectByStudentDTO
    {
        public Guid Id_Students { get; set; }
        public int Id_Subject { get; set; }
    }
}

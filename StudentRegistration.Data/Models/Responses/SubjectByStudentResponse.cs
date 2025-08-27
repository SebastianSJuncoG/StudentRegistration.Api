using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Models.Responses
{
    public class SubjectByStudentResponse
    {
        public Guid Id_Students { get; set; }
        public int Id_Subject { get; set; }
        public string Subject_Name { get; set; }
        public int Num_Credits { get; set; }
    }
}

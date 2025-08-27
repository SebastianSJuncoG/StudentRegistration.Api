using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Data.Models.Responses
{
    public class SubjectByTeacherResponse
    {
        public Guid Id_Teacher { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Id_Subject { get; set; }
        public string Subject_Name { get; set; }
        public int Num_Credits { get; set; }
    }
}

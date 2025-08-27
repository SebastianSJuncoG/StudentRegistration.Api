using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Services.DTOs
{
    public class ProgramDTO
    {
        public int IdProgram { get; set; }

        public string ProgramName { get; set; } = null!;

        public int NumCredits { get; set; }
    }
}

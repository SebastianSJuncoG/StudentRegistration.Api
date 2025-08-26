using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class Program
{
    public int IdProgram { get; set; }

    public string ProgramName { get; set; } = null!;

    public int NumCredits { get; set; }

    public virtual ICollection<ProgramStudent> ProgramStudents { get; set; } = new List<ProgramStudent>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}

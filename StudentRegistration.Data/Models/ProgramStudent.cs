using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class ProgramStudent
{
    public int IdProgramStudent { get; set; }

    public int IdProgram { get; set; }

    public Guid IdStudents { get; set; }

    public virtual Program IdProgramNavigation { get; set; } = null!;

    public virtual Student IdStudentsNavigation { get; set; } = null!;
}

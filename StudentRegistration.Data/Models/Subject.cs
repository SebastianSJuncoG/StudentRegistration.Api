using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class Subject
{
    public int IdSubject { get; set; }

    public int IdProgram { get; set; }

    public string SubjectName { get; set; } = null!;

    public int NumCredits { get; set; }

    public virtual Program IdProgramNavigation { get; set; } = null!;

    public virtual ICollection<SubjectStudent> SubjectStudents { get; set; } = new List<SubjectStudent>();

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();
}

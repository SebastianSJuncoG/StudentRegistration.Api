using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class SubjectTeacher
{
    public int IdSubjectTeacher { get; set; }

    public int IdSubject { get; set; }

    public Guid IdTeacher { get; set; }

    public virtual Subject IdSubjectNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}

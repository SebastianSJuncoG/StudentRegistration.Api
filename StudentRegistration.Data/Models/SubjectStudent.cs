using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class SubjectStudent
{
    public int IdSubjectStudent { get; set; }

    public int IdSubject { get; set; }

    public Guid IdStudents { get; set; }

    public virtual Student IdStudentsNavigation { get; set; } = null!;

    public virtual Subject IdSubjectNavigation { get; set; } = null!;
}

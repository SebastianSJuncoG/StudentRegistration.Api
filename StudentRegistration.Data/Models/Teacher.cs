using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class Teacher
{
    public Guid IdTeacher { get; set; }

    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public int IdIdentificationType { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public virtual IdentificationType IdIdentificationTypeNavigation { get; set; } = null!;

    public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; } = new List<SubjectTeacher>();

    public virtual UsersLogin User { get; set; } = null!;
}

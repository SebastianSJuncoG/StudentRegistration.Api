using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class UsersLogin
{
    public Guid IdUsers { get; set; }

    public string UserName { get; set; } = null!;

    public string? TempPassword { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? Salt { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int BlockingAttempts { get; set; }

    public DateTime? DateLastLogin { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Administrative> Administratives { get; set; } = new List<Administrative>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}

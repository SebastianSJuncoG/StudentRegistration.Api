using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? TempPassword { get; set; }

    public byte[]? PasswordHash { get; set; }

    public byte[]? Salt { get; set; }

    public string? Email { get; set; }

    public int IdCountry { get; set; }

    public int IdIdentificationType { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public DateTime UpdateDate { get; set; }

    public int BlockingAttempts { get; set; }

    public DateTime? DateLastLogin { get; set; }

    public bool Active { get; set; }

    public virtual IdentificationType IdIdentificationTypeNavigation { get; set; } = null!;
}

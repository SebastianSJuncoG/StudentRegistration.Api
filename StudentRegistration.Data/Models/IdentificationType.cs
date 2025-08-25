using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class IdentificationType
{
    public int Id { get; set; }

    public string? IdentificationTypeName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

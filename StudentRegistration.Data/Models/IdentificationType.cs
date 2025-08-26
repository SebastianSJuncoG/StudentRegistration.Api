using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class IdentificationType
{
    public int IdIdentificationType { get; set; }

    public string? IdentificationTypeName { get; set; }

    public virtual ICollection<Administrative> Administratives { get; set; } = new List<Administrative>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}

using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class TypeOfEvent
{
    public int Id { get; set; }

    public string? EventName { get; set; }

    public virtual ICollection<LogUser> LogUsers { get; set; } = new List<LogUser>();
}

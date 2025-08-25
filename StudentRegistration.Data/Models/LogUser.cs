using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class LogUser
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime DateRegister { get; set; }

    public int IdTypeEvent { get; set; }

    public string? EventDetails { get; set; }

    public string? ErrorMessage { get; set; }

    public string? IpRegister { get; set; }

    public virtual TypeOfEvent IdTypeEventNavigation { get; set; } = null!;
}

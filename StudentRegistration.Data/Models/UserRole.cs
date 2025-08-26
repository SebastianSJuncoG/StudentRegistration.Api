using System;
using System.Collections.Generic;

namespace StudentRegistration.Data.Models;

public partial class UserRole
{
    public int IdUserRoles { get; set; }

    public Guid IdUsers { get; set; }

    public int IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual UsersLogin IdUsersNavigation { get; set; } = null!;
}

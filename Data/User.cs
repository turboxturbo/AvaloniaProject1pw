using System;
using System.Collections.Generic;

namespace AvaloniaProject1pw.Data;

public partial class User
{
    public int IdUser { get; set; }

    public string FullName { get; set; } = null!;

    public int IdRole { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}

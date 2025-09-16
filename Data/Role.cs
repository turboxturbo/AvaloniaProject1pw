﻿using System;
using System.Collections.Generic;

namespace AvaloniaProject1pw.Data;

public partial class Role
{
    public int IdRole { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}

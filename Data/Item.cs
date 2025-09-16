using System;
using System.Collections.Generic;

namespace AvaloniaProject1pw.Data;

public partial class Item
{
    public int IdItem { get; set; }

    public string? NameItem { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();
}

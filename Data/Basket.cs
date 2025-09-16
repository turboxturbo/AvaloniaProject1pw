using System;
using System.Collections.Generic;

namespace AvaloniaProject1pw.Data;

public partial class Basket
{
    public int IdBasket { get; set; }

    public int? IdItem { get; set; }

    public int? IdUser { get; set; }

    public virtual Item? IdItemNavigation { get; set; }

    public virtual User? IdUserNavigation { get; set; }
}

using System;
using System.Collections.Generic;

namespace Advanced_WPF.EF.Models;

public partial class Role
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}

using System;
using System.Collections.Generic;

namespace Advanced_WPF.EF.Models;

public partial class Worker
{
    public int Id { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Mobile { get; set; }

    public DateOnly? Dob { get; set; }

    public int? Income { get; set; }

    public string? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}

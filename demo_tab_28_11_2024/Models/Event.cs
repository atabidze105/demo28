using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class Event
{
    public int EventId { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string Purpose { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Teamuser> Teams { get; set; } = new List<Teamuser>();

    public virtual ICollection<SoloUser> Users { get; set; } = new List<SoloUser>();
}

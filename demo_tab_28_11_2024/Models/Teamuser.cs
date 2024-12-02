using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class Teamuser
{
    public int TeamId { get; set; }

    public string Teamlist { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}

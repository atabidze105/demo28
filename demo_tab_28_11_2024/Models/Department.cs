using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

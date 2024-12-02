using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class EmployeeCode
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class Employee
{
    public int UserId { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? UserPatronymic { get; set; }

    public string Department { get; set; } = null!;

    public int EmployeeCode { get; set; }

    public virtual EmployeeCode EmployeeCodeNavigation { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}

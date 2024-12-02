using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class SoloUser
{
    public int UserId { get; set; }

    public string UserSurname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? UserPatronymic { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string PassportSerie { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public string? Phone { get; set; }

    public string Email { get; set; } = null!;

    public string? OrganisationName { get; set; }

    public string? Purpose { get; set; }

    public string? Photo { get; set; }

    public bool Admin { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public Bitmap UserPhoto => new Bitmap(Photo != null ? $"Assets/{Photo}" : "Assets/solo.png");
}

using System;
using System.Collections.Generic;

namespace demo_tab_28_11_2024.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Articul { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Measure { get; set; } = null!;

    public float Cost { get; set; }

    public float MaxDiscount { get; set; }

    public float ActualDiscount { get; set; }

    public int QuantityStored { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int Cathegory { get; set; }

    public int Manufacturer { get; set; }

    public int Supplier { get; set; }

    public virtual Cathegory CathegoryNavigation { get; set; } = null!;

    public virtual Manufacturer ManufacturerNavigation { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Supplier SupplierNavigation { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ServicePackage
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string ServiceType { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int? Duration { get; set; }

    public string? Features { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

using System;
using System.Collections.Generic;

namespace api.Models;

public partial class MaintenanceRequest
{
    public Guid Id { get; set; }

    public Guid ContractId { get; set; }

    public Guid TenantId { get; set; }

    public Guid LandlordId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public string? Status { get; set; }

    public string? Images { get; set; }

    public string? Response { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public virtual RentalContract Contract { get; set; } = null!;

    public virtual User Landlord { get; set; } = null!;

    public virtual User Tenant { get; set; } = null!;
}

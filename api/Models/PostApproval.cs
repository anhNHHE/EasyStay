using System;
using System.Collections.Generic;

namespace api.Models;

public partial class PostApproval
{
    public Guid Id { get; set; }

    public Guid RoomId { get; set; }

    public Guid LandlordId { get; set; }

    public DateTime? RequestedDate { get; set; }

    public string? Status { get; set; }

    public Guid? ReviewedBy { get; set; }

    public DateTime? ReviewedDate { get; set; }

    public string? RejectionReason { get; set; }

    public string? Notes { get; set; }

    public virtual User Landlord { get; set; } = null!;

    public virtual User? ReviewedByNavigation { get; set; }

    public virtual Room Room { get; set; } = null!;
}

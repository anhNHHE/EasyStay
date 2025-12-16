using System;
using System.Collections.Generic;

namespace api.Models;

public partial class PostReport
{
    public Guid Id { get; set; }

    public Guid RoomId { get; set; }

    public Guid LandlordId { get; set; }

    public Guid ReportedBy { get; set; }

    public string Reason { get; set; } = null!;

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? AdminNotes { get; set; }

    public DateTime? WarningDeadline { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public DateTime? ResolvedAt { get; set; }

    public Guid? ReviewedBy { get; set; }

    public virtual User Landlord { get; set; } = null!;

    public virtual User ReportedByNavigation { get; set; } = null!;

    public virtual User? ReviewedByNavigation { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual ICollection<WarningNotification> WarningNotifications { get; set; } = new List<WarningNotification>();
}

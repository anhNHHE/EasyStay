using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ServiceBooking
{
    public Guid Id { get; set; }

    public string ServiceType { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public Guid RequestedBy { get; set; }

    public Guid? RoomId { get; set; }

    public Guid? ProviderId { get; set; }

    public DateTime ScheduledDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public string? Status { get; set; }

    public decimal Cost { get; set; }

    public decimal? PlatformCommissionRate { get; set; }

    public decimal? PlatformCommission { get; set; }

    public bool? IsPaid { get; set; }

    public bool? IsCommissionPaid { get; set; }

    public DateTime? CommissionPaidDate { get; set; }

    public int? Rating { get; set; }

    public string? Feedback { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CommissionPayment> CommissionPayments { get; set; } = new List<CommissionPayment>();

    public virtual ServiceProvider? Provider { get; set; }

    public virtual User RequestedByNavigation { get; set; } = null!;

    public virtual Room? Room { get; set; }
}

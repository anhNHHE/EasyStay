using System;
using System.Collections.Generic;

namespace api.Models;

public partial class CommissionPayment
{
    public Guid Id { get; set; }

    public Guid ProviderId { get; set; }

    public Guid BookingId { get; set; }

    public decimal ServiceCost { get; set; }

    public decimal CommissionRate { get; set; }

    public decimal CommissionAmount { get; set; }

    public string? Status { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? PaidDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ServiceBooking Booking { get; set; } = null!;

    public virtual ServiceProvider Provider { get; set; } = null!;
}

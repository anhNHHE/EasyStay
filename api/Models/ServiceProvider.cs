using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ServiceProvider
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? ServiceTypes { get; set; }

    public decimal? Rating { get; set; }

    public int? TotalJobs { get; set; }

    public int? CompletedJobs { get; set; }

    public decimal? TotalRevenue { get; set; }

    public decimal? TotalCommissionOwed { get; set; }

    public decimal? TotalCommissionPaid { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CommissionPayment> CommissionPayments { get; set; } = new List<CommissionPayment>();

    public virtual ICollection<ServiceBooking> ServiceBookings { get; set; } = new List<ServiceBooking>();
}

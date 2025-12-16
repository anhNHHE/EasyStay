using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ServiceRequest
{
    public Guid Id { get; set; }

    public Guid ServiceId { get; set; }

    public Guid RequesterId { get; set; }

    public string RoomAddress { get; set; } = null!;

    public DateOnly RequestedDate { get; set; }

    public string? PreferredTime { get; set; }

    public string? Status { get; set; }

    public decimal? EstimatedPrice { get; set; }

    public decimal? ActualPrice { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Requester { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}

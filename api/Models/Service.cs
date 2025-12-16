using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Service
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public string Provider { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public decimal PriceMin { get; set; }

    public decimal PriceMax { get; set; }

    public string PriceUnit { get; set; } = null!;

    public string? CoverageCities { get; set; }

    public string? CoverageDistricts { get; set; }

    public TimeOnly? AvailableHoursStart { get; set; }

    public TimeOnly? AvailableHoursEnd { get; set; }

    public decimal? Rating { get; set; }

    public int? ReviewCount { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<ServiceReview> ServiceReviews { get; set; } = new List<ServiceReview>();
}

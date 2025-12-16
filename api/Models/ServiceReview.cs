using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ServiceReview
{
    public Guid Id { get; set; }

    public Guid ServiceId { get; set; }

    public Guid ReviewerId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Reviewer { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}

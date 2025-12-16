using System;
using System.Collections.Generic;

namespace api.Models;

public partial class ActivityLog
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string ActivityType { get; set; } = null!;

    public string? Description { get; set; }

    public string? Metadata { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}

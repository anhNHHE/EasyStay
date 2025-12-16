using System;
using System.Collections.Generic;

namespace api.Models;

public partial class WarningNotification
{
    public Guid Id { get; set; }

    public Guid ReportId { get; set; }

    public Guid LandlordId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime Deadline { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Landlord { get; set; } = null!;

    public virtual PostReport Report { get; set; } = null!;
}

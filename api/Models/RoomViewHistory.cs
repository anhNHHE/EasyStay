using System;
using System.Collections.Generic;

namespace api.Models;

public partial class RoomViewHistory
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid RoomId { get; set; }

    public DateTime? ViewDate { get; set; }

    public int? DurationSeconds { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

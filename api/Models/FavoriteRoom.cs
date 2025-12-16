using System;
using System.Collections.Generic;

namespace api.Models;

public partial class FavoriteRoom
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid RoomId { get; set; }

    public string? Notes { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual Room Room { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace api.Models;

public partial class RoomImage
{
    public Guid Id { get; set; }

    public Guid RoomId { get; set; }

    public string Url { get; set; } = null!;

    public string? Type { get; set; }

    public string? Caption { get; set; }

    public int? DisplayOrder { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Room Room { get; set; } = null!;
}

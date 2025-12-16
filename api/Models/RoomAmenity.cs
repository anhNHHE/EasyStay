using System;
using System.Collections.Generic;

namespace api.Models;

public partial class RoomAmenity
{
    public Guid RoomId { get; set; }

    public Guid AmenityId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Amenity Amenity { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}

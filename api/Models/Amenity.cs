using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Amenity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Icon { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
}

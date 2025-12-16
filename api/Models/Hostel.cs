using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Hostel
{
    public Guid Id { get; set; }

    public Guid LandlordId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Address { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public int? TotalRooms { get; set; }

    public int? AvailableRooms { get; set; }

    public bool? HasParking { get; set; }

    public bool? HasSecurity { get; set; }

    public bool? HasElevator { get; set; }

    public string ContactPhone { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public string? Rules { get; set; }

    public string? Amenities { get; set; }

    public string? Images { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User Landlord { get; set; } = null!;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}

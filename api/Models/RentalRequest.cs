using System;
using System.Collections.Generic;

namespace api.Models;

public partial class RentalRequest
{
    public Guid Id { get; set; }

    public Guid RoomId { get; set; }

    public Guid RequesterId { get; set; }

    public Guid LandlordId { get; set; }

    public string? Message { get; set; }

    public DateOnly? MoveInDate { get; set; }

    public string? Status { get; set; }

    public string? RejectionReason { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ResponseDate { get; set; }

    public virtual User Landlord { get; set; } = null!;

    public virtual User Requester { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}

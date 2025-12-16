using System;
using System.Collections.Generic;

namespace api.Models;

public partial class Room
{
    public Guid Id { get; set; }

    public Guid LandlordId { get; set; }

    public Guid? HostelId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string Address { get; set; } = null!;

    public string District { get; set; } = null!;

    public string City { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Area { get; set; }

    public string RoomType { get; set; } = null!;

    public int? MaxOccupants { get; set; }

    public decimal? ElectricityPrice { get; set; }

    public decimal? WaterPrice { get; set; }

    public bool? InternetIncluded { get; set; }

    public bool? ParkingIncluded { get; set; }

    public bool? AirConditioned { get; set; }

    public bool? Furnished { get; set; }

    public bool? IsAvailable { get; set; }

    public bool? IsActive { get; set; }

    public string? ApprovalStatus { get; set; }

    public Guid? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public string? RejectionReason { get; set; }

    public int? ViewCount { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual User? ApprovedByNavigation { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<FavoriteRoom> FavoriteRooms { get; set; } = new List<FavoriteRoom>();

    public virtual Hostel? Hostel { get; set; }

    public virtual User Landlord { get; set; } = null!;

    public virtual ICollection<PostApproval> PostApprovals { get; set; } = new List<PostApproval>();

    public virtual ICollection<PostReport> PostReports { get; set; } = new List<PostReport>();

    public virtual ICollection<RentalContract> RentalContracts { get; set; } = new List<RentalContract>();

    public virtual ICollection<RentalRequest> RentalRequests { get; set; } = new List<RentalRequest>();

    public virtual ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();

    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();

    public virtual ICollection<RoomViewHistory> RoomViewHistories { get; set; } = new List<RoomViewHistory>();

    public virtual ICollection<ServiceBooking> ServiceBookings { get; set; } = new List<ServiceBooking>();
}

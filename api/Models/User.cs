using System;
using System.Collections.Generic;

namespace api.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Phone { get; set; }

    public string Role { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? IdCard { get; set; }

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string? EmergencyContactRelationship { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsEmailVerified { get; set; }

    public Guid? LinkedRoomId { get; set; }

    public int? AllowedPostsPerMonth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ActivityLog> ActivityLogs { get; set; } = new List<ActivityLog>();

    public virtual ICollection<Bill> BillLandlords { get; set; } = new List<Bill>();

    public virtual ICollection<Bill> BillTenants { get; set; } = new List<Bill>();

    public virtual ICollection<FavoriteRoom> FavoriteRooms { get; set; } = new List<FavoriteRoom>();

    public virtual ICollection<Hostel> Hostels { get; set; } = new List<Hostel>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestLandlords { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<MaintenanceRequest> MaintenanceRequestTenants { get; set; } = new List<MaintenanceRequest>();

    public virtual ICollection<PaymentHistory> PaymentHistories { get; set; } = new List<PaymentHistory>();

    public virtual ICollection<PostApproval> PostApprovalLandlords { get; set; } = new List<PostApproval>();

    public virtual ICollection<PostApproval> PostApprovalReviewedByNavigations { get; set; } = new List<PostApproval>();

    public virtual ICollection<PostQuota> PostQuota { get; set; } = new List<PostQuota>();

    public virtual ICollection<PostReport> PostReportLandlords { get; set; } = new List<PostReport>();

    public virtual ICollection<PostReport> PostReportReportedByNavigations { get; set; } = new List<PostReport>();

    public virtual ICollection<PostReport> PostReportReviewedByNavigations { get; set; } = new List<PostReport>();

    public virtual ICollection<RentalContract> RentalContractLandlords { get; set; } = new List<RentalContract>();

    public virtual ICollection<RentalContract> RentalContractTenants { get; set; } = new List<RentalContract>();

    public virtual ICollection<RentalRequest> RentalRequestLandlords { get; set; } = new List<RentalRequest>();

    public virtual ICollection<RentalRequest> RentalRequestRequesters { get; set; } = new List<RentalRequest>();

    public virtual ICollection<Room> RoomApprovedByNavigations { get; set; } = new List<Room>();

    public virtual ICollection<Room> RoomLandlords { get; set; } = new List<Room>();

    public virtual ICollection<RoomViewHistory> RoomViewHistories { get; set; } = new List<RoomViewHistory>();

    public virtual ICollection<ServiceBooking> ServiceBookings { get; set; } = new List<ServiceBooking>();

    public virtual ICollection<ServiceRequest> ServiceRequests { get; set; } = new List<ServiceRequest>();

    public virtual ICollection<ServiceReview> ServiceReviews { get; set; } = new List<ServiceReview>();

    public virtual ICollection<WarningNotification> WarningNotifications { get; set; } = new List<WarningNotification>();
}

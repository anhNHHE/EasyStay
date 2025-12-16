using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace api.Models;

public partial class EasyStayContext : DbContext
{
    public EasyStayContext()
    {
    }

    public EasyStayContext(DbContextOptions<EasyStayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActivityLog> ActivityLogs { get; set; }

    public virtual DbSet<Amenity> Amenities { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<CommissionPayment> CommissionPayments { get; set; }

    public virtual DbSet<FavoriteRoom> FavoriteRooms { get; set; }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<MaintenanceRequest> MaintenanceRequests { get; set; }

    public virtual DbSet<PaymentHistory> PaymentHistories { get; set; }

    public virtual DbSet<PostApproval> PostApprovals { get; set; }

    public virtual DbSet<PostQuota> PostQuotas { get; set; }

    public virtual DbSet<PostReport> PostReports { get; set; }

    public virtual DbSet<RentalContract> RentalContracts { get; set; }

    public virtual DbSet<RentalPayment> RentalPayments { get; set; }

    public virtual DbSet<RentalRequest> RentalRequests { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAmenity> RoomAmenities { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<RoomViewHistory> RoomViewHistories { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceBooking> ServiceBookings { get; set; }

    public virtual DbSet<ServicePackage> ServicePackages { get; set; }

    public virtual DbSet<ServiceProvider> ServiceProviders { get; set; }

    public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }

    public virtual DbSet<ServiceReview> ServiceReviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UtilityReading> UtilityReadings { get; set; }

    public virtual DbSet<VBillDetail> VBillDetails { get; set; }

    public virtual DbSet<VLandlordDashboard> VLandlordDashboards { get; set; }

    public virtual DbSet<WarningNotification> WarningNotifications { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=.;Database=RoomRentalSystem;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(
                config.GetConnectionString("EasyStayDB")
            );
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActivityLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__activity__3213E83FFF95D05C");

            entity.ToTable("activity_logs");

            entity.HasIndex(e => e.CreatedAt, "idx_activity_logs_created");

            entity.HasIndex(e => e.ActivityType, "idx_activity_logs_type");

            entity.HasIndex(e => e.UserId, "idx_activity_logs_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(30)
                .HasColumnName("activity_type");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(45)
                .HasColumnName("ip_address");
            entity.Property(e => e.Metadata).HasColumnName("metadata");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ActivityLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__activity___user___251C81ED");
        });

        modelBuilder.Entity<Amenity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__amenitie__3213E83F665C581A");

            entity.ToTable("amenities");

            entity.HasIndex(e => e.Name, "UQ__amenitie__72E12F1BC3B2A864").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__bills__3213E83F2E300385");

            entity.ToTable("bills");

            entity.HasIndex(e => e.ContractId, "idx_bills_contract");

            entity.HasIndex(e => e.DueDate, "idx_bills_due_date");

            entity.HasIndex(e => e.LandlordId, "idx_bills_landlord");

            entity.HasIndex(e => new { e.Year, e.Month }, "idx_bills_period");

            entity.HasIndex(e => e.Status, "idx_bills_status");

            entity.HasIndex(e => e.TenantId, "idx_bills_tenant");

            entity.HasIndex(e => new { e.ContractId, e.Year, e.Month }, "unique_bill_contract_period").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.ElectricityCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("electricity_cost");
            entity.Property(e => e.ElectricityUsage)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("electricity_usage");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OtherFees)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("other_fees");
            entity.Property(e => e.PaidDate).HasColumnName("paid_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomRent)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("room_rent");
            entity.Property(e => e.ServiceFees)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("service_fees");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UtilityReadingId).HasColumnName("utility_reading_id");
            entity.Property(e => e.WaterCost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("water_cost");
            entity.Property(e => e.WaterUsage)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("water_usage");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Contract).WithMany(p => p.Bills)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__bills__contract___17F790F9");

            entity.HasOne(d => d.Landlord).WithMany(p => p.BillLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bills__landlord___1AD3FDA4");

            entity.HasOne(d => d.Room).WithMany(p => p.Bills)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bills__room_id__18EBB532");

            entity.HasOne(d => d.Tenant).WithMany(p => p.BillTenants)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__bills__tenant_id__19DFD96B");

            entity.HasOne(d => d.UtilityReading).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UtilityReadingId)
                .HasConstraintName("FK__bills__utility_r__1BC821DD");
        });

        modelBuilder.Entity<CommissionPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__commissi__3213E83F0AD1C1A3");

            entity.ToTable("commission_payments");

            entity.HasIndex(e => e.DueDate, "idx_commission_payments_due_date");

            entity.HasIndex(e => e.ProviderId, "idx_commission_payments_provider");

            entity.HasIndex(e => e.Status, "idx_commission_payments_status");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.CommissionAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("commission_amount");
            entity.Property(e => e.CommissionRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("commission_rate");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.PaidDate).HasColumnName("paid_date");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.ServiceCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("service_cost");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Booking).WithMany(p => p.CommissionPayments)
                .HasForeignKey(d => d.BookingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__commissio__booki__6BE40491");

            entity.HasOne(d => d.Provider).WithMany(p => p.CommissionPayments)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__commissio__provi__6AEFE058");
        });

        modelBuilder.Entity<FavoriteRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__favorite__3213E83FC60A6E4E");

            entity.ToTable("favorite_rooms");

            entity.HasIndex(e => e.RoomId, "idx_favorite_rooms_room");

            entity.HasIndex(e => e.UserId, "idx_favorite_rooms_user");

            entity.HasIndex(e => new { e.UserId, e.RoomId }, "unique_user_room").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("added_date");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Room).WithMany(p => p.FavoriteRooms)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__favorite___room___11158940");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteRooms)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__favorite___user___10216507");
        });

        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hostels__3213E83F8DAF6A5C");

            entity.ToTable("hostels", tb => tb.HasTrigger("trg_hostels_updated_at"));

            entity.HasIndex(e => e.City, "idx_hostels_city");

            entity.HasIndex(e => e.District, "idx_hostels_district");

            entity.HasIndex(e => e.LandlordId, "idx_hostels_landlord");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.Amenities).HasColumnName("amenities");
            entity.Property(e => e.AvailableRooms)
                .HasDefaultValue(0)
                .HasColumnName("available_rooms");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.HasElevator)
                .HasDefaultValue(false)
                .HasColumnName("has_elevator");
            entity.Property(e => e.HasParking)
                .HasDefaultValue(false)
                .HasColumnName("has_parking");
            entity.Property(e => e.HasSecurity)
                .HasDefaultValue(false)
                .HasColumnName("has_security");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Rules).HasColumnName("rules");
            entity.Property(e => e.TotalRooms)
                .HasDefaultValue(0)
                .HasColumnName("total_rooms");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Landlord).WithMany(p => p.Hostels)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__hostels__landlor__4AB81AF0");
        });

        modelBuilder.Entity<MaintenanceRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__maintena__3213E83F0AF5DF07");

            entity.ToTable("maintenance_requests");

            entity.HasIndex(e => e.Category, "idx_maintenance_requests_category");

            entity.HasIndex(e => e.ContractId, "idx_maintenance_requests_contract");

            entity.HasIndex(e => e.LandlordId, "idx_maintenance_requests_landlord");

            entity.HasIndex(e => e.Status, "idx_maintenance_requests_status");

            entity.HasIndex(e => e.TenantId, "idx_maintenance_requests_tenant");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.CompletedDate).HasColumnName("completed_date");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Images).HasColumnName("images");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Response).HasColumnName("response");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");

            entity.HasOne(d => d.Contract).WithMany(p => p.MaintenanceRequests)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__maintenan__contr__282DF8C2");

            entity.HasOne(d => d.Landlord).WithMany(p => p.MaintenanceRequestLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__maintenan__landl__2A164134");

            entity.HasOne(d => d.Tenant).WithMany(p => p.MaintenanceRequestTenants)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__maintenan__tenan__29221CFB");
        });

        modelBuilder.Entity<PaymentHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__payment___3213E83F834E4DD1");

            entity.ToTable("payment_history");

            entity.HasIndex(e => e.PaymentDate, "idx_payment_history_date");

            entity.HasIndex(e => e.Status, "idx_payment_history_status");

            entity.HasIndex(e => e.UserId, "idx_payment_history_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .HasColumnName("payment_method");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Bill).WithMany(p => p.PaymentHistories)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK__payment_h__bill___1F63A897");

            entity.HasOne(d => d.User).WithMany(p => p.PaymentHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__payment_h__user___1E6F845E");
        });

        modelBuilder.Entity<PostApproval>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post_app__3213E83F0FE274A4");

            entity.ToTable("post_approvals");

            entity.HasIndex(e => e.LandlordId, "idx_post_approvals_landlord");

            entity.HasIndex(e => e.ReviewedBy, "idx_post_approvals_reviewed_by");

            entity.HasIndex(e => e.RoomId, "idx_post_approvals_room");

            entity.HasIndex(e => e.Status, "idx_post_approvals_status");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.RequestedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("requested_date");
            entity.Property(e => e.ReviewedBy).HasColumnName("reviewed_by");
            entity.Property(e => e.ReviewedDate).HasColumnName("reviewed_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Landlord).WithMany(p => p.PostApprovalLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_appr__landl__73852659");

            entity.HasOne(d => d.ReviewedByNavigation).WithMany(p => p.PostApprovalReviewedByNavigations)
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("FK__post_appr__revie__74794A92");

            entity.HasOne(d => d.Room).WithMany(p => p.PostApprovals)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_appr__room___72910220");
        });

        modelBuilder.Entity<PostQuota>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post_quo__3213E83F2E40F77E");

            entity.ToTable("post_quotas");

            entity.HasIndex(e => e.LastResetDate, "idx_post_quotas_last_reset");

            entity.HasIndex(e => e.UserId, "idx_post_quotas_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CurrentMonthPosts)
                .HasDefaultValue(0)
                .HasColumnName("current_month_posts");
            entity.Property(e => e.LastResetDate).HasColumnName("last_reset_date");
            entity.Property(e => e.MaxPostsPerMonth).HasColumnName("max_posts_per_month");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.PostQuota)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_quot__user___793DFFAF");
        });

        modelBuilder.Entity<PostReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post_rep__3213E83FD6083E87");

            entity.ToTable("post_reports");

            entity.HasIndex(e => e.LandlordId, "idx_post_reports_landlord");

            entity.HasIndex(e => e.Reason, "idx_post_reports_reason");

            entity.HasIndex(e => e.ReportedBy, "idx_post_reports_reported_by");

            entity.HasIndex(e => e.RoomId, "idx_post_reports_room");

            entity.HasIndex(e => e.Status, "idx_post_reports_status");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AdminNotes).HasColumnName("admin_notes");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Reason)
                .HasMaxLength(30)
                .HasColumnName("reason");
            entity.Property(e => e.ReportedBy).HasColumnName("reported_by");
            entity.Property(e => e.ResolvedAt).HasColumnName("resolved_at");
            entity.Property(e => e.ReviewedAt).HasColumnName("reviewed_at");
            entity.Property(e => e.ReviewedBy).HasColumnName("reviewed_by");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.WarningDeadline).HasColumnName("warning_deadline");

            entity.HasOne(d => d.Landlord).WithMany(p => p.PostReportLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_repo__landl__01D345B0");

            entity.HasOne(d => d.ReportedByNavigation).WithMany(p => p.PostReportReportedByNavigations)
                .HasForeignKey(d => d.ReportedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_repo__repor__02C769E9");

            entity.HasOne(d => d.ReviewedByNavigation).WithMany(p => p.PostReportReviewedByNavigations)
                .HasForeignKey(d => d.ReviewedBy)
                .HasConstraintName("FK__post_repo__revie__03BB8E22");

            entity.HasOne(d => d.Room).WithMany(p => p.PostReports)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__post_repo__room___00DF2177");
        });

        modelBuilder.Entity<RentalContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rental_c__3213E83F123EF0F3");

            entity.ToTable("rental_contracts", tb =>
                {
                    tb.HasTrigger("trg_update_room_on_contract_create");
                    tb.HasTrigger("trg_update_room_on_contract_end");
                });

            entity.HasIndex(e => new { e.StartDate, e.EndDate }, "idx_rental_contracts_dates");

            entity.HasIndex(e => e.LandlordId, "idx_rental_contracts_landlord");

            entity.HasIndex(e => e.RoomId, "idx_rental_contracts_room");

            entity.HasIndex(e => e.ContractStatus, "idx_rental_contracts_status");

            entity.HasIndex(e => e.TenantId, "idx_rental_contracts_tenant");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ContractNotes).HasColumnName("contract_notes");
            entity.Property(e => e.ContractStatus)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("contract_status");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DepositAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("deposit_amount");
            entity.Property(e => e.ElectricityRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("electricity_rate");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.MonthlyRent)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("monthly_rent");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.ServiceFees)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("service_fees");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.TerminatedDate).HasColumnName("terminated_date");
            entity.Property(e => e.TerminationReason).HasColumnName("termination_reason");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.WaterRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("water_rate");

            entity.HasOne(d => d.Landlord).WithMany(p => p.RentalContractLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_co__landl__01142BA1");

            entity.HasOne(d => d.Room).WithMany(p => p.RentalContracts)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_co__room___7F2BE32F");

            entity.HasOne(d => d.Tenant).WithMany(p => p.RentalContractTenants)
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_co__tenan__00200768");
        });

        modelBuilder.Entity<RentalPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rental_p__3213E83F36D3A6EF");

            entity.ToTable("rental_payments");

            entity.HasIndex(e => e.BillId, "idx_rental_payments_bill");

            entity.HasIndex(e => e.PaymentDate, "idx_rental_payments_date");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");

            entity.HasOne(d => d.Bill).WithMany(p => p.RentalPayments)
                .HasForeignKey(d => d.BillId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_pa__bill___208CD6FA");
        });

        modelBuilder.Entity<RentalRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rental_r__3213E83F5E37B2E8");

            entity.ToTable("rental_requests");

            entity.HasIndex(e => e.RequestDate, "idx_rental_requests_date");

            entity.HasIndex(e => e.LandlordId, "idx_rental_requests_landlord");

            entity.HasIndex(e => e.RequesterId, "idx_rental_requests_requester");

            entity.HasIndex(e => e.RoomId, "idx_rental_requests_room");

            entity.HasIndex(e => e.Status, "idx_rental_requests_status");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.MoveInDate).HasColumnName("move_in_date");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("request_date");
            entity.Property(e => e.RequesterId).HasColumnName("requester_id");
            entity.Property(e => e.ResponseDate).HasColumnName("response_date");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");

            entity.HasOne(d => d.Landlord).WithMany(p => p.RentalRequestLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_re__landl__76969D2E");

            entity.HasOne(d => d.Requester).WithMany(p => p.RentalRequestRequesters)
                .HasForeignKey(d => d.RequesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_re__reque__75A278F5");

            entity.HasOne(d => d.Room).WithMany(p => p.RentalRequests)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rental_re__room___74AE54BC");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rooms__3213E83F064A9736");

            entity.ToTable("rooms", tb => tb.HasTrigger("trg_rooms_updated_at"));

            entity.HasIndex(e => e.ApprovalStatus, "idx_rooms_approval_status");

            entity.HasIndex(e => e.IsAvailable, "idx_rooms_available");

            entity.HasIndex(e => new { e.City, e.District }, "idx_rooms_city_district");

            entity.HasIndex(e => e.HostelId, "idx_rooms_hostel");

            entity.HasIndex(e => e.LandlordId, "idx_rooms_landlord");

            entity.HasIndex(e => e.Price, "idx_rooms_price");

            entity.HasIndex(e => e.RoomType, "idx_rooms_room_type");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.AirConditioned)
                .HasDefaultValue(false)
                .HasColumnName("air_conditioned");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("approval_status");
            entity.Property(e => e.ApprovedAt).HasColumnName("approved_at");
            entity.Property(e => e.ApprovedBy).HasColumnName("approved_by");
            entity.Property(e => e.Area)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("area");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.District)
                .HasMaxLength(100)
                .HasColumnName("district");
            entity.Property(e => e.ElectricityPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("electricity_price");
            entity.Property(e => e.Furnished)
                .HasDefaultValue(false)
                .HasColumnName("furnished");
            entity.Property(e => e.HostelId).HasColumnName("hostel_id");
            entity.Property(e => e.InternetIncluded)
                .HasDefaultValue(false)
                .HasColumnName("internet_included");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .HasColumnName("is_available");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.MaxOccupants)
                .HasDefaultValue(1)
                .HasColumnName("max_occupants");
            entity.Property(e => e.ParkingIncluded)
                .HasDefaultValue(false)
                .HasColumnName("parking_included");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");
            entity.Property(e => e.RejectionReason).HasColumnName("rejection_reason");
            entity.Property(e => e.RoomType)
                .HasMaxLength(20)
                .HasColumnName("room_type");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.ViewCount)
                .HasDefaultValue(0)
                .HasColumnName("view_count");
            entity.Property(e => e.WaterPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("water_price");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.RoomApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__rooms__approved___619B8048");

            entity.HasOne(d => d.Hostel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HostelId)
                .HasConstraintName("FK__rooms__hostel_id__60A75C0F");

            entity.HasOne(d => d.Landlord).WithMany(p => p.RoomLandlords)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__rooms__landlord___5FB337D6");
        });

        modelBuilder.Entity<RoomAmenity>(entity =>
        {
            entity.HasKey(e => new { e.RoomId, e.AmenityId }).HasName("PK__room_ame__D7F7DED8421D13A7");

            entity.ToTable("room_amenities");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.AmenityId).HasColumnName("amenity_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");

            entity.HasOne(d => d.Amenity).WithMany(p => p.RoomAmenities)
                .HasForeignKey(d => d.AmenityId)
                .HasConstraintName("FK__room_amen__ameni__6E01572D");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAmenities)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__room_amen__room___6D0D32F4");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__room_ima__3213E83FCB9A91FC");

            entity.ToTable("room_images");

            entity.HasIndex(e => e.DisplayOrder, "idx_room_images_order");

            entity.HasIndex(e => e.RoomId, "idx_room_images_room");

            entity.HasIndex(e => e.Type, "idx_room_images_type");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Caption)
                .HasMaxLength(200)
                .HasColumnName("caption");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DisplayOrder)
                .HasDefaultValue(0)
                .HasColumnName("display_order");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .HasDefaultValue("other")
                .HasColumnName("type");
            entity.Property(e => e.Url)
                .HasMaxLength(500)
                .HasColumnName("url");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomImages)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__room_imag__room___693CA210");
        });

        modelBuilder.Entity<RoomViewHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__room_vie__3213E83F59906AF5");

            entity.ToTable("room_view_history");

            entity.HasIndex(e => e.ViewDate, "idx_room_view_history_date");

            entity.HasIndex(e => e.RoomId, "idx_room_view_history_room");

            entity.HasIndex(e => e.UserId, "idx_room_view_history_user");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.DurationSeconds).HasColumnName("duration_seconds");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ViewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("view_date");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomViewHistories)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__room_view__room___16CE6296");

            entity.HasOne(d => d.User).WithMany(p => p.RoomViewHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__room_view__user___15DA3E5D");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__services__3213E83FD3E94B03");

            entity.ToTable("services");

            entity.HasIndex(e => e.IsActive, "idx_services_active");

            entity.HasIndex(e => e.Category, "idx_services_category");

            entity.HasIndex(e => e.Rating, "idx_services_rating");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.AvailableHoursEnd).HasColumnName("available_hours_end");
            entity.Property(e => e.AvailableHoursStart).HasColumnName("available_hours_start");
            entity.Property(e => e.Category)
                .HasMaxLength(20)
                .HasColumnName("category");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .HasColumnName("contact_phone");
            entity.Property(e => e.CoverageCities).HasColumnName("coverage_cities");
            entity.Property(e => e.CoverageDistricts).HasColumnName("coverage_districts");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.PriceMax)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_max");
            entity.Property(e => e.PriceMin)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price_min");
            entity.Property(e => e.PriceUnit)
                .HasMaxLength(20)
                .HasColumnName("price_unit");
            entity.Property(e => e.Provider)
                .HasMaxLength(200)
                .HasColumnName("provider");
            entity.Property(e => e.Rating)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.ReviewCount)
                .HasDefaultValue(0)
                .HasColumnName("review_count");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServiceBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F9FE6FDD5");

            entity.ToTable("service_bookings");

            entity.HasIndex(e => e.ProviderId, "idx_service_bookings_provider");

            entity.HasIndex(e => e.RequestedBy, "idx_service_bookings_requested_by");

            entity.HasIndex(e => e.ScheduledDate, "idx_service_bookings_scheduled");

            entity.HasIndex(e => e.Status, "idx_service_bookings_status");

            entity.HasIndex(e => e.ServiceType, "idx_service_bookings_type");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CommissionPaidDate).HasColumnName("commission_paid_date");
            entity.Property(e => e.CompletedDate).HasColumnName("completed_date");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.IsCommissionPaid)
                .HasDefaultValue(false)
                .HasColumnName("is_commission_paid");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasColumnName("is_paid");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PlatformCommission)
                .HasComputedColumnSql("(([cost]*[platform_commission_rate])/(100))", true)
                .HasColumnType("decimal(22, 8)")
                .HasColumnName("platform_commission");
            entity.Property(e => e.PlatformCommissionRate)
                .HasDefaultValue(1500m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("platform_commission_rate");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.RequestedBy).HasColumnName("requested_by");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.ScheduledDate).HasColumnName("scheduled_date");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .HasColumnName("service_type");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Provider).WithMany(p => p.ServiceBookings)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK__service_b__provi__5D95E53A");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.ServiceBookings)
                .HasForeignKey(d => d.RequestedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__service_b__reque__5BAD9CC8");

            entity.HasOne(d => d.Room).WithMany(p => p.ServiceBookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__service_b__room___5CA1C101");
        });

        modelBuilder.Entity<ServicePackage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83FCD8F5D89");

            entity.ToTable("service_packages");

            entity.HasIndex(e => e.IsActive, "idx_service_packages_active");

            entity.HasIndex(e => e.ServiceType, "idx_service_packages_type");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Features).HasColumnName("features");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .HasColumnName("service_type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServiceProvider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F93968C86");

            entity.ToTable("service_providers");

            entity.HasIndex(e => e.IsActive, "idx_service_providers_active");

            entity.HasIndex(e => e.Rating, "idx_service_providers_rating");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CompletedJobs)
                .HasDefaultValue(0)
                .HasColumnName("completed_jobs");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Rating)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.ServiceTypes).HasColumnName("service_types");
            entity.Property(e => e.TotalCommissionOwed)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_commission_owed");
            entity.Property(e => e.TotalCommissionPaid)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_commission_paid");
            entity.Property(e => e.TotalJobs)
                .HasDefaultValue(0)
                .HasColumnName("total_jobs");
            entity.Property(e => e.TotalRevenue)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(15, 2)")
                .HasColumnName("total_revenue");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ServiceRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F032966E5");

            entity.ToTable("service_requests");

            entity.HasIndex(e => e.RequestedDate, "idx_service_requests_date");

            entity.HasIndex(e => e.RequesterId, "idx_service_requests_requester");

            entity.HasIndex(e => e.ServiceId, "idx_service_requests_service");

            entity.HasIndex(e => e.Status, "idx_service_requests_status");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ActualPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("actual_price");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.EstimatedPrice)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("estimated_price");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.PreferredTime)
                .HasMaxLength(50)
                .HasColumnName("preferred_time");
            entity.Property(e => e.RequestedDate).HasColumnName("requested_date");
            entity.Property(e => e.RequesterId).HasColumnName("requester_id");
            entity.Property(e => e.RoomAddress)
                .HasMaxLength(300)
                .HasColumnName("room_address");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Requester).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.RequesterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__service_r__reque__3D2915A8");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceRequests)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__service_r__servi__3C34F16F");
        });

        modelBuilder.Entity<ServiceReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__service___3213E83F5F637DEB");

            entity.ToTable("service_reviews", tb => tb.HasTrigger("trg_update_service_rating"));

            entity.HasIndex(e => e.Rating, "idx_service_reviews_rating");

            entity.HasIndex(e => e.ReviewerId, "idx_service_reviews_reviewer");

            entity.HasIndex(e => e.ServiceId, "idx_service_reviews_service");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewerId).HasColumnName("reviewer_id");
            entity.Property(e => e.ServiceId).HasColumnName("service_id");

            entity.HasOne(d => d.Reviewer).WithMany(p => p.ServiceReviews)
                .HasForeignKey(d => d.ReviewerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__service_r__revie__43D61337");

            entity.HasOne(d => d.Service).WithMany(p => p.ServiceReviews)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__service_r__servi__42E1EEFE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F0A964040");

            entity.ToTable("users", tb => tb.HasTrigger("trg_users_updated_at"));

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164B3E64F9C").IsUnique();

            entity.HasIndex(e => e.Email, "idx_users_email");

            entity.HasIndex(e => e.IsActive, "idx_users_is_active");

            entity.HasIndex(e => e.Phone, "idx_users_phone");

            entity.HasIndex(e => e.Role, "idx_users_role");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasColumnName("address");
            entity.Property(e => e.AllowedPostsPerMonth)
                .HasDefaultValue(10)
                .HasColumnName("allowed_posts_per_month");
            entity.Property(e => e.Avatar)
                .HasMaxLength(500)
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyContactName)
                .HasMaxLength(100)
                .HasColumnName("emergency_contact_name");
            entity.Property(e => e.EmergencyContactPhone)
                .HasMaxLength(20)
                .HasColumnName("emergency_contact_phone");
            entity.Property(e => e.EmergencyContactRelationship)
                .HasMaxLength(50)
                .HasColumnName("emergency_contact_relationship");
            entity.Property(e => e.IdCard)
                .HasMaxLength(20)
                .HasColumnName("id_card");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsEmailVerified)
                .HasDefaultValue(false)
                .HasColumnName("is_email_verified");
            entity.Property(e => e.LinkedRoomId).HasColumnName("linked_room_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("guest")
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<UtilityReading>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__utility___3213E83F8A3CB80F");

            entity.ToTable("utility_readings");

            entity.HasIndex(e => e.ContractId, "idx_utility_readings_contract");

            entity.HasIndex(e => new { e.Year, e.Month }, "idx_utility_readings_period");

            entity.HasIndex(e => new { e.ContractId, e.Year, e.Month }, "unique_contract_period").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.ElectricityCurrent)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("electricity_current");
            entity.Property(e => e.ElectricityPrevious)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("electricity_previous");
            entity.Property(e => e.ElectricityUsage)
                .HasComputedColumnSql("([electricity_current]-[electricity_previous])", true)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("electricity_usage");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.ReadingDate).HasColumnName("reading_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updated_at");
            entity.Property(e => e.WaterCurrent)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("water_current");
            entity.Property(e => e.WaterPrevious)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("water_previous");
            entity.Property(e => e.WaterUsage)
                .HasComputedColumnSql("([water_current]-[water_previous])", true)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("water_usage");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Contract).WithMany(p => p.UtilityReadings)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__utility_r__contr__08B54D69");
        });

        modelBuilder.Entity<VBillDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_bill_details");

            entity.Property(e => e.ContractId).HasColumnName("contract_id");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.ElectricityCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("electricity_cost");
            entity.Property(e => e.ElectricityUsage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("electricity_usage");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LandlordEmail)
                .HasMaxLength(100)
                .HasColumnName("landlord_email");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.LandlordName)
                .HasMaxLength(100)
                .HasColumnName("landlord_name");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.OtherFees)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("other_fees");
            entity.Property(e => e.PaidDate).HasColumnName("paid_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.RoomAddress)
                .HasMaxLength(300)
                .HasColumnName("room_address");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomRent)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("room_rent");
            entity.Property(e => e.RoomTitle)
                .HasMaxLength(200)
                .HasColumnName("room_title");
            entity.Property(e => e.ServiceFees)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("service_fees");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TenantEmail)
                .HasMaxLength(100)
                .HasColumnName("tenant_email");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.TenantName)
                .HasMaxLength(100)
                .HasColumnName("tenant_name");
            entity.Property(e => e.TenantPhone)
                .HasMaxLength(20)
                .HasColumnName("tenant_phone");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(100)
                .HasColumnName("transaction_id");
            entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            entity.Property(e => e.UtilityReadingId).HasColumnName("utility_reading_id");
            entity.Property(e => e.WaterCost)
                .HasColumnType("decimal(12, 2)")
                .HasColumnName("water_cost");
            entity.Property(e => e.WaterUsage)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("water_usage");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<VLandlordDashboard>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_landlord_dashboard");

            entity.Property(e => e.ActiveContracts).HasColumnName("active_contracts");
            entity.Property(e => e.AvailableRooms).HasColumnName("available_rooms");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.LandlordName)
                .HasMaxLength(100)
                .HasColumnName("landlord_name");
            entity.Property(e => e.MonthlyRevenue)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("monthly_revenue");
            entity.Property(e => e.OccupiedRooms).HasColumnName("occupied_rooms");
            entity.Property(e => e.PendingBills).HasColumnName("pending_bills");
            entity.Property(e => e.TotalRooms).HasColumnName("total_rooms");
        });

        modelBuilder.Entity<WarningNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__warning___3213E83F7CA6B5F6");

            entity.ToTable("warning_notifications");

            entity.HasIndex(e => e.Deadline, "idx_warning_notifications_deadline");

            entity.HasIndex(e => e.IsRead, "idx_warning_notifications_is_read");

            entity.HasIndex(e => e.LandlordId, "idx_warning_notifications_landlord");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("created_at");
            entity.Property(e => e.Deadline).HasColumnName("deadline");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.LandlordId).HasColumnName("landlord_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ReportId).HasColumnName("report_id");

            entity.HasOne(d => d.Landlord).WithMany(p => p.WarningNotifications)
                .HasForeignKey(d => d.LandlordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__warning_n__landl__0A688BB1");

            entity.HasOne(d => d.Report).WithMany(p => p.WarningNotifications)
                .HasForeignKey(d => d.ReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__warning_n__repor__09746778");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

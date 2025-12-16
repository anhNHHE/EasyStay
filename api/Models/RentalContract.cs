using System;
using System.Collections.Generic;

namespace api.Models;

public partial class RentalContract
{
    public Guid Id { get; set; }

    public Guid RoomId { get; set; }

    public Guid TenantId { get; set; }

    public Guid LandlordId { get; set; }

    public decimal MonthlyRent { get; set; }

    public decimal DepositAmount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string? ContractStatus { get; set; }

    public decimal ElectricityRate { get; set; }

    public decimal WaterRate { get; set; }

    public decimal? ServiceFees { get; set; }

    public string? ContractNotes { get; set; }

    public string? TerminationReason { get; set; }

    public DateOnly? TerminatedDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual User Landlord { get; set; } = null!;

    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    public virtual Room Room { get; set; } = null!;

    public virtual User Tenant { get; set; } = null!;

    public virtual ICollection<UtilityReading> UtilityReadings { get; set; } = new List<UtilityReading>();
}

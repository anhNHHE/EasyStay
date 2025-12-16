using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VBillDetail
{
    public Guid Id { get; set; }

    public Guid ContractId { get; set; }

    public Guid RoomId { get; set; }

    public Guid TenantId { get; set; }

    public Guid LandlordId { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public Guid? UtilityReadingId { get; set; }

    public decimal RoomRent { get; set; }

    public decimal? ElectricityUsage { get; set; }

    public decimal? ElectricityCost { get; set; }

    public decimal? WaterUsage { get; set; }

    public decimal? WaterCost { get; set; }

    public decimal? ServiceFees { get; set; }

    public decimal? OtherFees { get; set; }

    public decimal TotalAmount { get; set; }

    public DateOnly DueDate { get; set; }

    public DateOnly? PaidDate { get; set; }

    public string? Status { get; set; }

    public string? PaymentMethod { get; set; }

    public string? TransactionId { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string RoomTitle { get; set; } = null!;

    public string RoomAddress { get; set; } = null!;

    public string TenantName { get; set; } = null!;

    public string TenantEmail { get; set; } = null!;

    public string? TenantPhone { get; set; }

    public string LandlordName { get; set; } = null!;

    public string LandlordEmail { get; set; } = null!;
}

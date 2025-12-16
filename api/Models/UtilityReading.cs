using System;
using System.Collections.Generic;

namespace api.Models;

public partial class UtilityReading
{
    public Guid Id { get; set; }

    public Guid ContractId { get; set; }

    public int Month { get; set; }

    public int Year { get; set; }

    public decimal ElectricityPrevious { get; set; }

    public decimal ElectricityCurrent { get; set; }

    public decimal? ElectricityUsage { get; set; }

    public decimal WaterPrevious { get; set; }

    public decimal WaterCurrent { get; set; }

    public decimal? WaterUsage { get; set; }

    public DateOnly ReadingDate { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual RentalContract Contract { get; set; } = null!;
}

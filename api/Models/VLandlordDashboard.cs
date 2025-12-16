using System;
using System.Collections.Generic;

namespace api.Models;

public partial class VLandlordDashboard
{
    public Guid LandlordId { get; set; }

    public string LandlordName { get; set; } = null!;

    public int? TotalRooms { get; set; }

    public int? AvailableRooms { get; set; }

    public int? OccupiedRooms { get; set; }

    public int? ActiveContracts { get; set; }

    public decimal MonthlyRevenue { get; set; }

    public int? PendingBills { get; set; }
}

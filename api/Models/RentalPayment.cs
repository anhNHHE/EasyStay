using System;
using System.Collections.Generic;

namespace api.Models;

public partial class RentalPayment
{
    public Guid Id { get; set; }

    public Guid BillId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly PaymentDate { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? TransactionId { get; set; }

    public string? Notes { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Bill Bill { get; set; } = null!;
}

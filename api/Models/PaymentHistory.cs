using System;
using System.Collections.Generic;

namespace api.Models;

public partial class PaymentHistory
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid? BillId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime? PaymentDate { get; set; }

    public string? TransactionId { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Bill? Bill { get; set; }

    public virtual User User { get; set; } = null!;
}

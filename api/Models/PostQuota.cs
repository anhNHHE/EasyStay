using System;
using System.Collections.Generic;

namespace api.Models;

public partial class PostQuota
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int MaxPostsPerMonth { get; set; }

    public int? CurrentMonthPosts { get; set; }

    public DateOnly LastResetDate { get; set; }

    public virtual User User { get; set; } = null!;
}

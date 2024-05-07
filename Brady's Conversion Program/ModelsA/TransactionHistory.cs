using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TransactionHistory
{
    public long TransactionId { get; set; }

    public long? StaffId { get; set; }

    public string? EventCategory { get; set; }

    public string? EventSponsorId { get; set; }

    public string? EventType { get; set; }

    public string? EventDetails { get; set; }

    public int? Quantity { get; set; }

    public DateTime? EventDateTime { get; set; }

    public string? Notes { get; set; }
}

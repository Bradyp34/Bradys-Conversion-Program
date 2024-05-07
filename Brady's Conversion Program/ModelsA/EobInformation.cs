using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EobInformation
{
    public long EobId { get; set; }

    public string Name { get; set; } = null!;

    public string NpiNumber { get; set; } = null!;

    public DateOnly IssuedDate { get; set; }

    public DateOnly ReceivedDate { get; set; }

    public string CheckNumber { get; set; } = null!;

    public decimal CheckAmount { get; set; }

    public DateOnly PaymentDate { get; set; }

    public string? Batch { get; set; }

    public string Notes { get; set; } = null!;

    public string Reference { get; set; } = null!;

    public bool Active { get; set; }
}

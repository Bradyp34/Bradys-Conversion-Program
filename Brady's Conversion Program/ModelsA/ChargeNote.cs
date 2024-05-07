using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargeNote
{
    public long ChargeNoteId { get; set; }

    public long OrderChargeId { get; set; }

    public int? CategoryId { get; set; }

    public string Notes { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ExternalSystemChargesList
{
    public int Id { get; set; }

    public long OrderId { get; set; }

    public DateTime EventDateTime { get; set; }

    public int? Processed { get; set; }

    public DateTime? ProcessedDateTime { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabelPrinter
{
    public long LabelPrinterId { get; set; }

    public string UserAssignedPrinterName { get; set; } = null!;

    public string LabelTemplate { get; set; } = null!;

    public string LabelPrinterName { get; set; } = null!;

    public long LocationId { get; set; }

    public bool Active { get; set; }

    public bool? Is550OrOlder { get; set; }
}

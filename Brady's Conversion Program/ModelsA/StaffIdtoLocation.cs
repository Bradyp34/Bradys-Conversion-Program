using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class StaffIdtoLocation
{
    public long Uid { get; set; }

    public long StaffId { get; set; }

    public long LocationId { get; set; }

    public string? PrinterName { get; set; }

    public long? NumberOfReceipts { get; set; }

    public bool? DoNotPrintReceipt { get; set; }

    public bool PrintNonCcpaymentsReceipt { get; set; }
}

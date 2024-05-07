using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class RxPrintInformation
{
    public long RxPrintId { get; set; }

    public long OrderId { get; set; }

    public int StaffId { get; set; }

    public DateTime? RxPrintedDateTime { get; set; }

    public string RxFilePath { get; set; } = null!;
}

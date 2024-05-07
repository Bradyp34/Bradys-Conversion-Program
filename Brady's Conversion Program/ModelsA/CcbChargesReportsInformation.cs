﻿using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CcbChargesReportsInformation
{
    public long Id { get; set; }

    public long StaffId { get; set; }

    public string Type { get; set; } = null!;

    public DateTime ReportDateTime { get; set; }

    public string ReportFilePath { get; set; } = null!;

    public string ExcelFilePath { get; set; } = null!;
}

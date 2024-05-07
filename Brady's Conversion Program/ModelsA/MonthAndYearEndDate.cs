using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MonthAndYearEndDate
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public string Type { get; set; } = null!;

    public int StaffId { get; set; }

    public int EomMonth { get; set; }

    public int EomYear { get; set; }

    public int EoyYear { get; set; }
}

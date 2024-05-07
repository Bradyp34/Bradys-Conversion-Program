using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class StaffLevel
{
    public int LevelId { get; set; }

    public string LevelName { get; set; } = null!;

    public int SortOrder { get; set; }

    public int StatusId { get; set; }
}

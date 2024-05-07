using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientSearch
{
    public int PtSearchId { get; set; }

    public string SearchName { get; set; } = null!;

    public string SearchParameters { get; set; } = null!;
}

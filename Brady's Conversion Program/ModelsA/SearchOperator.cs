using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SearchOperator
{
    public int OperatorId { get; set; }

    public string Operator { get; set; } = null!;

    public int SortOrder { get; set; }
}

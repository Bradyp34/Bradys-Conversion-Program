using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrdrugListRxNorm
{
    public int TableId { get; set; }

    public string? DrugMappingId { get; set; }

    public string? RxCui { get; set; }

    public int? IsPrescribable { get; set; }

    public string? ActiveStatus { get; set; }
}

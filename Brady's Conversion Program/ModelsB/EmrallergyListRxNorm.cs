using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrallergyListRxNorm
{
    public int TableId { get; set; }

    public string? MappingId { get; set; }

    public string? ConceptId { get; set; }

    public string? RxCui { get; set; }

    public string? ActiveStatus { get; set; }
}

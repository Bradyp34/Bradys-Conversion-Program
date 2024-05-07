using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrcolumnControlList
{
    public int TableId { get; set; }

    public int? ControlId { get; set; }

    public string? Text { get; set; }

    public int? ColumnNumber { get; set; }

    public int? ParentTableId { get; set; }

    public int? CodeId { get; set; }

    public string? DestField { get; set; }

    public int? SortOrder { get; set; }

    public short? Prioritize { get; set; }

    public int? ModalityId { get; set; }

    public string? InsertGuid { get; set; }

    public string? Snomed { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientObservationValue
{
    public int PtObservationValueId { get; set; }

    public int PtObservationId { get; set; }

    public int PtId { get; set; }

    public string Value { get; set; } = null!;

    public string ValueType { get; set; } = null!;

    public string? ValueCode { get; set; }

    public int CodeSystemId { get; set; }

    public string InsertGuid { get; set; } = null!;

    public int? ParentId { get; set; }
}

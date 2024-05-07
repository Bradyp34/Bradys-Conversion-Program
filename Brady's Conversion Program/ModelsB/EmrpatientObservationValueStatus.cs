using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientObservationValueStatus
{
    public int PtObservationValueStatusId { get; set; }

    public int PtObservationValueId { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public DateTime RecordedDate { get; set; }

    public string Description { get; set; } = null!;

    public string? Code { get; set; }

    public int? CodeSystemId { get; set; }

    public string? Note { get; set; }

    public string InsertGuid { get; set; } = null!;
}

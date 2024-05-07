using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientObservation
{
    public int PtObservationId { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public DateTime RecordedDate { get; set; }

    public DateTime ObservationDate { get; set; }

    public DateTime? ObservationDateEnd { get; set; }

    public string? ObservationCode { get; set; }

    public int CodeSystemId { get; set; }

    public string? RelatedRecordId { get; set; }

    public int? RelatedRecordType { get; set; }

    public string InsertGuid { get; set; } = null!;
}

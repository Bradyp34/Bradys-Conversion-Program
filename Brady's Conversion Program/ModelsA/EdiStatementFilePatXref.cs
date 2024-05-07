using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiStatementFilePatXref
{
    public long EdiStmtFilePatXrefId { get; set; }

    public long EdiStmtFileId { get; set; }

    public long EdiStmtFilePatientId { get; set; }

    public int? StatusId { get; set; }

    public string? ResponseStatus { get; set; }

    public string? ResponseStatusMessage { get; set; }

    public DateTime? ResponseDate { get; set; }
}

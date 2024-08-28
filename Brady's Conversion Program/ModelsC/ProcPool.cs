using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class ProcPool
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? ProcText { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? OriginalModifier { get; set; }

    public string? Location { get; set; }

    public string? SourceField { get; set; }

    public string? IsBilled { get; set; }

    public string? ProcLocationType { get; set; }

    public string? ProcDiagTestComponents { get; set; }

    public string? NotPorelated { get; set; }

    public string? ProcType { get; set; }

    public string? BillMultiProcId { get; set; }

    public string? BillMultiProcControlId { get; set; }

    public string? AdditionalModifier { get; set; }

    public string? IsQr { get; set; }

    public string? EyeMdqrnum { get; set; }

    public string? Pqrsnum { get; set; }

    public string? Nqfnum { get; set; }

    public string? Numerator { get; set; }

    public string? Denominator { get; set; }

    public string? IsHidden { get; set; }

    public string? Qrcomponent { get; set; }

    public string? Units { get; set; }

    public string? RequestedProcedureId { get; set; }

    public string? SentInVisit { get; set; }

    public string? SourceRecordId { get; set; }

    public string? InitialPatientPopulation { get; set; }

    public string? DenominatorExclusion { get; set; }

    public string? DenominatorException { get; set; }

    public string? BillingOrder { get; set; }

    public string? Active { get; set; }
}

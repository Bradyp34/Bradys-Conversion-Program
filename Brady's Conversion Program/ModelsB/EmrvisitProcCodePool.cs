using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitProcCodePool
{
    public int VisitProcCodePoolId { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public int? ControlId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? ProcText { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? OriginalModifier { get; set; }

    public string? Location { get; set; }

    public string? SourceField { get; set; }

    public short IsBilled { get; set; }

    /// <summary>
    /// 1 = Not Location Specific, 2 = Unilateral/Lid Specific - Add Location Modifiers,  3=Bilateral - Do not add Location Modifiers, 4 = Bilateral - Add Location and 52 if not both eyes.
    /// </summary>
    public int? ProcLocationType { get; set; }

    /// <summary>
    /// True = Can Split Technical &amp; Professional Components
    /// </summary>
    public short ProcDiagTestComponents { get; set; }

    public short? NotPorelated { get; set; }

    public int? ProcType { get; set; }

    public int? BillMultiProcId { get; set; }

    public int? BillMultiProcControlId { get; set; }

    public string? AdditionalModifier { get; set; }

    public short? IsQr { get; set; }

    public string? EyeMdqrnum { get; set; }

    public string? Pqrsnum { get; set; }

    public string? Nqfnum { get; set; }

    public int? Numerator { get; set; }

    public int? Denominator { get; set; }

    public short? IsHidden { get; set; }

    public string? Qrcomponent { get; set; }

    public string? InsertGuid { get; set; }

    public int? Units { get; set; }

    public int? RequestedProcedureId { get; set; }

    public short? SentInVisit { get; set; }

    public int? SourceRecordId { get; set; }

    public int? InitialPatientPopulation { get; set; }

    public int? DenominatorExclusion { get; set; }

    public int? DenominatorException { get; set; }

    public int BillingOrder { get; set; }
}

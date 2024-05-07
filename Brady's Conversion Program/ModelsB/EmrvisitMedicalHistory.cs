using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitMedicalHistory
{
    public int VisitMedicalHistoryId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public int? ControlId { get; set; }

    public DateTime? Dosdate { get; set; }

    public int? OrigVisitMedicalHistoryId { get; set; }

    public int? OrigVisitDiagCodePoolId { get; set; }

    public DateTime? OrigDosdate { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public int? TypeId { get; set; }

    public string? Location1 { get; set; }

    public short? Severity1 { get; set; }

    public string? OnsetMonth1 { get; set; }

    public string? OnsetDay1 { get; set; }

    public string? OnsetYear1 { get; set; }

    public string? Location2 { get; set; }

    public int? Location2OnsetVisitId { get; set; }

    public short? Severity2 { get; set; }

    public string? OnsetMonth2 { get; set; }

    public string? OnsetDay2 { get; set; }

    public string? OnsetYear2 { get; set; }

    public short? IsResolved1 { get; set; }

    public int? ResolvedVisitId1 { get; set; }

    public int? ResolvedRequestedProcedureId1 { get; set; }

    public DateTime? ResolvedDate1 { get; set; }

    public string? ResolveType1 { get; set; }

    public short? IsResolved2 { get; set; }

    public int? ResolvedVisitId2 { get; set; }

    public int? ResolvedRequestedProcedureId2 { get; set; }

    public DateTime? ResolvedDate2 { get; set; }

    public string? ResolveType2 { get; set; }

    public string? Notes { get; set; }

    public string? InsertGuid { get; set; }

    public bool DoNotReconcile { get; set; }

    public DateTime? LastModified { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedEmpId { get; set; }

    public int? LastModifiedEmpId { get; set; }
}

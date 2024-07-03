using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class MedicalHistory
{
    public int Id { get; set; }

    public string? VisitId { get; set; }

    public string? PtId { get; set; }

    public string? Dosdate { get; set; }

    public string? ControlId { get; set; }

    public string? OrigVisitMedicalHistoryId { get; set; }

    public string? OrigVisitDiagCodePoolId { get; set; }

    public string? OrigDosdate { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public string? TypeId { get; set; }

    public string? Location1 { get; set; }

    public string? Severity1 { get; set; }

    public string? OnsetMonth1 { get; set; }

    public string? OnsetDay1 { get; set; }

    public string? OnsetYear1 { get; set; }

    public string? Location2 { get; set; }

    public string? Location2OnsetVisitId { get; set; }

    public string? Severity2 { get; set; }

    public string? OnsetMonth2 { get; set; }

    public string? OnsetDay2 { get; set; }

    public string? OnsetYear2 { get; set; }

    public string? IsResolved1 { get; set; }

    public string? ResolvedVisitId1 { get; set; }

    public string? ResolvedRequestedProcedureId1 { get; set; }

    public string? ResolvedDate1 { get; set; }

    public string? ResolveType1 { get; set; }

    public string? IsResolved2 { get; set; }

    public string? ResolvedVisitId2 { get; set; }

    public string? ResolvedRequestedProcedureId2 { get; set; }

    public string? ResolvedDate2 { get; set; }

    public string? ResolveType2 { get; set; }

    public string? Notes { get; set; }

    public string? DoNotReconcile { get; set; }

    public string? LastModified { get; set; }

    public string? Created { get; set; }

    public string? CreatedEmpId { get; set; }

    public string? LastModifiedEmpId { get; set; }
}

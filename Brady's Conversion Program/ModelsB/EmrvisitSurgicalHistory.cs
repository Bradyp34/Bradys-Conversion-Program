using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitSurgicalHistory
{
    public int VisitSurgicalHistoryId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public int? ControlId { get; set; }

    public DateTime? VisitDate { get; set; }

    public int? OrigVisitSurgicalHistoryId { get; set; }

    public DateTime? OrigVisitDate { get; set; }

    public string? Description { get; set; }

    public int? TypeId { get; set; }

    public int? CodeId { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public string? Location1 { get; set; }

    public string? ProcedureMonth1 { get; set; }

    public string? ProcedureDay1 { get; set; }

    public string? ProcedureYear1 { get; set; }

    public int? PerformedbyEmpId1 { get; set; }

    public int? PerformedbyRefProviderId1 { get; set; }

    public string? PerformedbyFullName1 { get; set; }

    public int? ComanageEmpId1 { get; set; }

    public int? ComanageRefProviderId1 { get; set; }

    public string? ComanageFullName1 { get; set; }

    public string? Location2 { get; set; }

    public string? ProcedureMonth2 { get; set; }

    public string? ProcedureDay2 { get; set; }

    public string? ProcedureYear2 { get; set; }

    public int? PerformedbyEmpId2 { get; set; }

    public int? PerformedbyRefProviderId2 { get; set; }

    public string? PerformedbyFullName2 { get; set; }

    public int? ComanageEmpId2 { get; set; }

    public int? ComanageRefProviderId2 { get; set; }

    public string? ComanageFullName2 { get; set; }

    public string? Notes { get; set; }

    public string? InsertGuid { get; set; }

    public bool DoNotReconcile { get; set; }

    public int? PtDeviceId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastModified { get; set; }

    public int? CreatedEmpId { get; set; }

    public int? LastModifiedEmpId { get; set; }
}

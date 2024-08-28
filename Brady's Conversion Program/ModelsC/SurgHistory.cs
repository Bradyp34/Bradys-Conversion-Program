using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class SurgHistory
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? OrigVisitSurgicalHistoryId { get; set; }

    public string? OrigVisitDate { get; set; }

    public string? Description { get; set; }

    public string? TypeId { get; set; }

    public string? CodeId { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public string? Location1 { get; set; }

    public string? ProcedureMonth1 { get; set; }

    public string? ProcedureDay1 { get; set; }

    public string? ProcedureYear1 { get; set; }

    public string? PerformedbyEmpId1 { get; set; }

    public string? PerformedbyRefProviderId1 { get; set; }

    public string? PerformedbyFullName1 { get; set; }

    public string? ComanageEmpId1 { get; set; }

    public string? ComanageRefProviderId1 { get; set; }

    public string? ComanageFullName1 { get; set; }

    public string? Location2 { get; set; }

    public string? ProcedureMonth2 { get; set; }

    public string? ProcedureDay2 { get; set; }

    public string? ProcedureYear2 { get; set; }

    public string? PerformedbyEmpId2 { get; set; }

    public string? PerformedbyRefProviderId2 { get; set; }

    public string? PerformedbyFullName2 { get; set; }

    public string? ComanageEmpId2 { get; set; }

    public string? ComanageRefProviderId2 { get; set; }

    public string? ComanageFullName2 { get; set; }

    public string? Notes { get; set; }

    public string? DoNotReconcile { get; set; }

    public string? PtDeviceId { get; set; }

    public string? Active { get; set; }
}

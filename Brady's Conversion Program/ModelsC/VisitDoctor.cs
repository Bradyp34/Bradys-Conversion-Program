using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class VisitDoctor
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? OldVisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? SlediagOd { get; set; }

    public string? SlediagOs { get; set; }

    public string? Slecomments { get; set; }

    public string? DfecdratioVertOd { get; set; }

    public string? DfecdratioHorizOd { get; set; }

    public string? DfecdratioVertOs { get; set; }

    public string? DfecdratioHorizOs { get; set; }

    public string? DfediagOd { get; set; }

    public string? DfediagOs { get; set; }

    public string? Dfecomments { get; set; }

    public string? DiagOtherDiagnoses { get; set; }

    public string? PlanStaffOrderComments { get; set; }

    public string? PlanRtowhen { get; set; }

    public string? PlanRtoreason { get; set; }

    public string? PlanDictateReferingDoc { get; set; }

    public string? PlanDictatePriCareDoc { get; set; }

    public string? PlanDictatePatient { get; set; }

    public string? PlanNextScheduledAppt { get; set; }

    public string? CodingMdm { get; set; }

    public string? CodingAdditionalProcedures { get; set; }

    public string? PlanRxMedRemarks { get; set; }

    public string? PlanRxOrdersRemarks { get; set; }

    public string? DfeextOpth { get; set; }

    public string? DfelensUsed { get; set; }

    public string? PlanTargetIopod { get; set; }

    public string? PlanTargetIopos { get; set; }

    public string? DfedilatedPupilSizeOd { get; set; }

    public string? DfedilatedPupilSizeOs { get; set; }

    public string? PlanDictateEyeCareDoc { get; set; }

    public string? PlanLensRxNotes { get; set; }

    public string? ProvidedClinicalSummary { get; set; }

    public string? ProvidedClinicalSummaryDays { get; set; }

    public string? Sleabutehl { get; set; }

    public string? ScribeEmpId { get; set; }

    public string? CodingC3emlevel { get; set; }

    public string? CodingC3eyeCareLevel { get; set; }

    public string? PddistOu { get; set; }

    public string? PdnearOu { get; set; }

    public string? Active { get; set; }
}

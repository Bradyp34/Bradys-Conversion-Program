using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitDoctor
{
    public int VisitDoctorId { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? SleDiagOd { get; set; }

    public string? SleDiagOs { get; set; }

    public string? Slecomments { get; set; }

    public string? DfeCdratioVertOd { get; set; }

    public string? DfeCdratioHorizOd { get; set; }

    public string? DfeCdratioVertOs { get; set; }

    public string? DfeCdratioHorizOs { get; set; }

    public string? DfeDiagOd { get; set; }

    public string? DfeDiagOs { get; set; }

    public string? Dfecomments { get; set; }

    public string? DiagOtherDiagnoses { get; set; }

    public string? PlanStaffOrderComments { get; set; }

    public string? PlanRtowhen { get; set; }

    public string? PlanRtoreason { get; set; }

    public short PlanDictateReferingDoc { get; set; }

    public short PlanDictatePriCareDoc { get; set; }

    public short PlanDictatePatient { get; set; }

    public string? PlanNextScheduledAppt { get; set; }

    public int? CodingMdm { get; set; }

    public string? CodingAdditionalProcedures { get; set; }

    public string? PlanRxMedRemarks { get; set; }

    public string? PlanRxOrdersRemarks { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public short? CodingChargesSent { get; set; }

    public short? DfeextOpth { get; set; }

    public string? DfelensUsed { get; set; }

    public string? PlanTargetIopOd { get; set; }

    public string? PlanTargetIopOs { get; set; }

    public string? DfedilatedPupilSizeOd { get; set; }

    public string? DfedilatedPupilSizeOs { get; set; }

    public short? PlanDictateEyeCareDoc { get; set; }

    public short? SentToWebPortal { get; set; }

    public int? SentToWebPortalDays { get; set; }

    public string? PlanLensRxNotes { get; set; }

    public short? ProvidedClinicalSummary { get; set; }

    public int? ProvidedClinicalSummaryDays { get; set; }

    public short? CodingQrautoCheckStatus { get; set; }

    public short? SleAbutehl { get; set; }

    public int? ScribeEmpId { get; set; }

    public int? CodingC3emlevel { get; set; }

    public int? CodingC3eyeCareLevel { get; set; }

    public string? PdDistOu { get; set; }

    public string? PdNearOu { get; set; }
}

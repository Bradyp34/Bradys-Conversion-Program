using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

[Table("VisitDoctor")]
public partial class VisitDoctor
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("OldVisitID")]
    public int? OldVisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("SLEDiagOD")]
    [Unicode(false)]
    public string? SlediagOd { get; set; }

    [Column("SLEDiagOS")]
    [Unicode(false)]
    public string? SlediagOs { get; set; }

    [Column("SLEComments")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Slecomments { get; set; }

    [Column("DFECDRatioVertOD")]
    [StringLength(250)]
    [Unicode(false)]
    public string? DfecdratioVertOd { get; set; }

    [Column("DFECDRatioHorizOD")]
    [StringLength(250)]
    [Unicode(false)]
    public string? DfecdratioHorizOd { get; set; }

    [Column("DFECDRatioVertOS")]
    [StringLength(250)]
    [Unicode(false)]
    public string? DfecdratioVertOs { get; set; }

    [Column("DFECDRatioHorizOS")]
    [StringLength(250)]
    [Unicode(false)]
    public string? DfecdratioHorizOs { get; set; }

    [Column("DFEDiagOD")]
    [Unicode(false)]
    public string? DfediagOd { get; set; }

    [Column("DFEDiagOS")]
    [Unicode(false)]
    public string? DfediagOs { get; set; }

    [Column("DFEComments")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Dfecomments { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DiagOtherDiagnoses { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PlanStaffOrderComments { get; set; }

    [Column("PlanRTOWhen")]
    [StringLength(250)]
    [Unicode(false)]
    public string? PlanRtowhen { get; set; }

    [Column("PlanRTOReason")]
    [StringLength(250)]
    [Unicode(false)]
    public string? PlanRtoreason { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PlanDictateReferingDoc { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PlanDictatePriCareDoc { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PlanDictatePatient { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PlanNextScheduledAppt { get; set; }

    [Column("CodingMDM")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CodingMdm { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? CodingAdditionalProcedures { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PlanRxMedRemarks { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PlanRxOrdersRemarks { get; set; }

    [Column("DFEExtOpth")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DfeextOpth { get; set; }

    [Column("DFELensUsed")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DfelensUsed { get; set; }

    [Column("PlanTargetIOPOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PlanTargetIopod { get; set; }

    [Column("PlanTargetIOPOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PlanTargetIopos { get; set; }

    [Column("DFEDilatedPupilSizeOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DfedilatedPupilSizeOd { get; set; }

    [Column("DFEDilatedPupilSizeOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DfedilatedPupilSizeOs { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PlanDictateEyeCareDoc { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PlanLensRxNotes { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ProvidedClinicalSummary { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ProvidedClinicalSummaryDays { get; set; }

    [Column("SLEABUTEHL")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Sleabutehl { get; set; }

    [Column("ScribeEmpID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ScribeEmpId { get; set; }

    [Column("CodingC3EMLevel")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CodingC3emlevel { get; set; }

    [Column("CodingC3EyeCareLevel")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CodingC3eyeCareLevel { get; set; }

    [Column("PDDistOU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PddistOu { get; set; }

    [Column("PDNearOU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PdnearOu { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

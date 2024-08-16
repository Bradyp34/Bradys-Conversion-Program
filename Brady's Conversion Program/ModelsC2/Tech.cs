using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("tech")]
public partial class Tech
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("PMHFHOther")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Pmhfhother { get; set; }

    [Column("PMHSmoking")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Pmhsmoking { get; set; }

    [Column("PMHSmokeHowMuch")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhsmokeHowMuch { get; set; }

    [Column("PMHSmokeHowLong")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhsmokeHowLong { get; set; }

    [Column("PMHSmokeWhenQuit")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhsmokeWhenQuit { get; set; }

    [Column("PMHAlcohol")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Pmhalcohol { get; set; }

    [Column("PMHAlcoholHowMuch")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhalcoholHowMuch { get; set; }

    [Column("PMHDrugs")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Pmhdrugs { get; set; }

    [Column("PMHDrugsNames")]
    [StringLength(500)]
    [Unicode(false)]
    public string? PmhdrugsNames { get; set; }

    [Column("PMHDrugsHowMuch")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhdrugsHowMuch { get; set; }

    [Column("PMHDrugsHowLong")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhdrugsHowLong { get; set; }

    [Column("PMHDrugsWhenQuit")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmhdrugsWhenQuit { get; set; }

    [Column("HPIChiefComplaint")]
    [StringLength(500)]
    [Unicode(false)]
    public string? HpichiefComplaint { get; set; }

    [Column("HPILocation1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpilocation1 { get; set; }

    [Column("HPIQuality1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpiquality1 { get; set; }

    [Column("HPISeverity1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpiseverity1 { get; set; }

    [Column("HPITiming1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpitiming1 { get; set; }

    [Column("HPIDuration1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpiduration1 { get; set; }

    [Column("HPIContext1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpicontext1 { get; set; }

    [Column("HPIModFactors1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? HpimodFactors1 { get; set; }

    [Column("HPIAssoSignsSymp1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? HpiassoSignsSymp1 { get; set; }

    [Column("HPI1LetterText")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Hpi1letterText { get; set; }

    [Column("WUVACCOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvaccod { get; set; }

    [Column("WUVACCOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvaccos { get; set; }

    [Column("WUVACCType")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Wuvacctype { get; set; }

    [Column("WUVASCOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvascod { get; set; }

    [Column("WUVASCOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvascos { get; set; }

    [Column("WUVAPHOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvaphod { get; set; }

    [Column("WUVAPHOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvaphos { get; set; }

    [Column("WUNCCOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wunccod { get; set; }

    [Column("WUNCCOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wunccos { get; set; }

    [Column("WUNSCOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wunscod { get; set; }

    [Column("WUNSCOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wunscos { get; set; }

    [Column("WUDomEye")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WudomEye { get; set; }

    [Column("WUTCVFOD")]
    [Unicode(false)]
    public string? Wutcvfod { get; set; }

    [Column("WUTCVFOS")]
    [Unicode(false)]
    public string? Wutcvfos { get; set; }

    [Column("WUCVFDiagOD")]
    [StringLength(500)]
    [Unicode(false)]
    public string? WucvfdiagOd { get; set; }

    [Column("WUCVFDiagOS")]
    [StringLength(500)]
    [Unicode(false)]
    public string? WucvfdiagOs { get; set; }

    [Column("WUEOMSuTmOD")]
    [Unicode(false)]
    public string? WueomsuTmOd { get; set; }

    [Column("WUEOMSuNaOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueomsuNaOd { get; set; }

    [Column("WUEOMTemporalOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueomtemporalOd { get; set; }

    [Column("WUEOMMedialOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueommedialOd { get; set; }

    [Column("WUEOMInTmOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueominTmOd { get; set; }

    [Column("WUEOMInNaOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueominNaOd { get; set; }

    [Column("WUEOMSuNaOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueomsuNaOs { get; set; }

    [Column("WUEOMSuTmOS")]
    [Unicode(false)]
    public string? WueomsuTmOs { get; set; }

    [Column("WUEOMMedialOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueommedialOs { get; set; }

    [Column("WUEOMTemporalOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueomtemporalOs { get; set; }

    [Column("WUEOMInNaOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueominNaOs { get; set; }

    [Column("WUEOMInTmOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WueominTmOs { get; set; }

    [Column("WUPupilDarkSizeOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilDarkSizeOd { get; set; }

    [Column("WUPupilLightSizeOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilLightSizeOd { get; set; }

    [Column("WUPupilReactionOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilReactionOd { get; set; }

    [Column("WUPupilShapeOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilShapeOd { get; set; }

    [Column("WUPupilAPDOD")]
    [Unicode(false)]
    public string? WupupilApdod { get; set; }

    [Column("WUPupilDarkSizeOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilDarkSizeOs { get; set; }

    [Column("WUPupilLightSizeOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilLightSizeOs { get; set; }

    [Column("WUPupilReactionOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilReactionOs { get; set; }

    [Column("WUPupilShapeOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilShapeOs { get; set; }

    [Column("WUPupilAPDOS")]
    [Unicode(false)]
    public string? WupupilApdos { get; set; }

    [Column("WUEXTOrbits")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wuextorbits { get; set; }

    [Column("WUEXTLids")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wuextlids { get; set; }

    [Column("WUEXTPAN")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Wuextpan { get; set; }

    [Column("WUMood")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Wumood { get; set; }

    [Column("WUOrientPerson")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WuorientPerson { get; set; }

    [Column("WUOrientPlace")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WuorientPlace { get; set; }

    [Column("WUOrientSituation")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WuorientSituation { get; set; }

    [Column("WUOrientTime")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WuorientTime { get; set; }

    [Column("WUDilated")]
    [Unicode(false)]
    public string? Wudilated { get; set; }

    [Column("WUDilatedTime")]
    [StringLength(20)]
    [Unicode(false)]
    public string? WudilatedTime { get; set; }

    [Column("WUDilatedEye")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WudilatedEye { get; set; }

    [Column("WUDilatedAgent")]
    [StringLength(500)]
    [Unicode(false)]
    public string? WudilatedAgent { get; set; }

    [Column("WUDilatedFrequency")]
    [StringLength(250)]
    [Unicode(false)]
    public string? WudilatedFrequency { get; set; }

    [Column("WUNotes")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wunotes { get; set; }

    [Column("HPIAdditionalComments1")]
    [StringLength(500)]
    [Unicode(false)]
    public string? HpiadditionalComments1 { get; set; }

    [Column("WUPupilNearOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilNearOd { get; set; }

    [Column("WUPupilNearOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WupupilNearOs { get; set; }

    [Column("WUAmslerOD")]
    [StringLength(250)]
    [Unicode(false)]
    public string? WuamslerOd { get; set; }

    [Column("WUAmslerOS")]
    [StringLength(250)]
    [Unicode(false)]
    public string? WuamslerOs { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsTemp { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsTempUnits { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsPulse { get; set; }

    [Column("VitalsBPSys")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsBpsys { get; set; }

    [Column("VitalsBPDia")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsBpdia { get; set; }

    [StringLength(250)]
    [Unicode(false)]
    public string? VitalsRespRate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsWeight { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsWeightUnits { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsHeight { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsHeightUnits { get; set; }

    [Column("VitalsBMI")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsBmi { get; set; }

    [Column("VitalsBGL")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsBgl { get; set; }

    [Column("VitalsBGLUnits")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VitalsBglunits { get; set; }

    [Column("HistoryMDReviewed")]
    [StringLength(50)]
    [Unicode(false)]
    public string? HistoryMdreviewed { get; set; }

    [Column("HistoryMDReviewedDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? HistoryMdreviewedDate { get; set; }

    [Column("HistoryMDReviewedEmpID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? HistoryMdreviewedEmpId { get; set; }

    [Column("WorkupMDReviewed")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WorkupMdreviewed { get; set; }

    [Column("WorkupMDReviewedDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? WorkupMdreviewedDate { get; set; }

    [Column("WorkupMDReviewedEmpID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WorkupMdreviewedEmpId { get; set; }

    [Column("PMHSmokingStatus")]
    [StringLength(100)]
    [Unicode(false)]
    public string? PmhsmokingStatus { get; set; }

    [Column("WUVACCOU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvaccou { get; set; }

    [Column("WUVASCOU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuvascou { get; set; }

    [Column("WUNCCOU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wunccou { get; set; }

    [Column("WUNSCOU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wunscou { get; set; }

    [Column("WUVATestUsed")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WuvatestUsed { get; set; }

    [Column("WUIOPABUTE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wuiopabute { get; set; }

    [Column("WUCVFABUTE")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wucvfabute { get; set; }

    [Column("WUEOMType")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Wueomtype { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MedRecNotPerformed { get; set; }

    [Column("WUDilatedTimeZone")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WudilatedTimeZone { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? VitalsPulseOximetry { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? VitalsInhaled02Concentration { get; set; }

    [Column("VitalsHOFCPercentile")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VitalsHofcpercentile { get; set; }

    [Column("VitalsWFLPercentile")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VitalsWflpercentile { get; set; }

    [Column("VitalsBMIPercentile")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VitalsBmipercentile { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Created { get; set; }

    [Column("CreatedEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CreatedEmpId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LasstModified { get; set; }

    [Column("LastModifiedEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LastModifiedEmpId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IntakeReconciled { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

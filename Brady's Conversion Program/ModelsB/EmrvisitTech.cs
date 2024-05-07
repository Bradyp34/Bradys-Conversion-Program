using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitTech
{
    public int VisitTechId { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? Pmhfhother { get; set; }

    public int? Pmhsmoking { get; set; }

    public string? PmhsmokeHowMuch { get; set; }

    public string? PmhsmokeHowLong { get; set; }

    public string? PmhsmokeWhenQuit { get; set; }

    public int? Pmhalcohol { get; set; }

    public string? PmhalcoholHowMuch { get; set; }

    public int? Pmhdrugs { get; set; }

    public string? PmhdrugsNames { get; set; }

    public string? PmhdrugsHowMuch { get; set; }

    public string? PmhdrugsHowLong { get; set; }

    public string? PmhdrugsWhenQuit { get; set; }

    public string? HpichiefComplaint { get; set; }

    public string? Hpilocation1 { get; set; }

    public string? Hpiquality1 { get; set; }

    public string? Hpiseverity1 { get; set; }

    public string? Hpitiming1 { get; set; }

    public string? Hpiduration1 { get; set; }

    public string? Hpicontext1 { get; set; }

    public string? HpimodFactors1 { get; set; }

    public string? HpiassoSignsSymp1 { get; set; }

    public string? Hpi1letterText { get; set; }

    public string? WuvaCcOd { get; set; }

    public string? WuvaCcOs { get; set; }

    /// <summary>
    /// 1=Spectacles, 2=Contact Lens
    /// </summary>
    public int? WuvaCcType { get; set; }

    public string? WuvaScOd { get; set; }

    public string? WuvaScOs { get; set; }

    public string? WuvaPhOd { get; set; }

    public string? WuvaPhOs { get; set; }

    public string? WunCcOd { get; set; }

    public string? WunCcOs { get; set; }

    public string? WunScOd { get; set; }

    public string? WunScOs { get; set; }

    public string? WudomEye { get; set; }

    public string? WutcvfOd { get; set; }

    public string? WutcvfOs { get; set; }

    public string? WucvfdiagOd { get; set; }

    public string? WucvfdiagOs { get; set; }

    public string? WueomSuTmOd { get; set; }

    public string? WueomSuNaOd { get; set; }

    public string? WueomTemporalOd { get; set; }

    public string? WueomMedialOd { get; set; }

    public string? WueomInTmOd { get; set; }

    public string? WueomInNaOd { get; set; }

    public string? WueomSuNaOs { get; set; }

    public string? WueomSuTmOs { get; set; }

    public string? WueomMedialOs { get; set; }

    public string? WueomTemporalOs { get; set; }

    public string? WueomInNaOs { get; set; }

    public string? WueomInTmOs { get; set; }

    public string? WupupilDarkSizeOd { get; set; }

    public string? WupupilLightSizeOd { get; set; }

    public string? WupupilReactionOd { get; set; }

    public string? WupupilShapeOd { get; set; }

    public string? WupupilApdOd { get; set; }

    public string? WupupilDarkSizeOs { get; set; }

    public string? WupupilLightSizeOs { get; set; }

    public string? WupupilReactionOs { get; set; }

    public string? WupupilShapeOs { get; set; }

    public string? WupupilApdOs { get; set; }

    public string? Wuextorbits { get; set; }

    public string? Wuextlids { get; set; }

    public int? Wuextpan { get; set; }

    public int? Wumood { get; set; }

    public int? WuorientPerson { get; set; }

    public int? WuorientPlace { get; set; }

    public int? WuorientSituation { get; set; }

    public int? WuorientTime { get; set; }

    public int? Wudilated { get; set; }

    public DateTime? WudilatedTime { get; set; }

    public string? WudilatedEye { get; set; }

    public string? WudilatedAgent { get; set; }

    public string? WudilatedFrequency { get; set; }

    public string? Wunotes { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public string? HpiadditionalComments1 { get; set; }

    public string? WupupilNearOd { get; set; }

    public string? WupupilNearOs { get; set; }

    public string? WuamslerOd { get; set; }

    public string? WuamslerOs { get; set; }

    public string? VitalsTemp { get; set; }

    public string? VitalsTempUnits { get; set; }

    public string? VitalsPulse { get; set; }

    public string? VitalsBpsys { get; set; }

    public string? VitalsBpdia { get; set; }

    public string? VitalsRespRate { get; set; }

    public string? VitalsWeight { get; set; }

    public string? VitalsWeightUnits { get; set; }

    public string? VitalsHeight { get; set; }

    public string? VitalsHeightUnits { get; set; }

    public string? VitalsBmi { get; set; }

    public string? VitalsBgl { get; set; }

    public string? VitalsBglunits { get; set; }

    public short? HistoryMdreviewed { get; set; }

    public DateTime? HistoryMdreviewedDate { get; set; }

    public int? HistoryMdreviewedEmpId { get; set; }

    public short? WorkupMdreviewed { get; set; }

    public DateTime? WorkupMdreviewedDate { get; set; }

    public int? WorkupMdreviewedEmpId { get; set; }

    public string? PmhsmokingStatus { get; set; }

    public string? WuvaCcOu { get; set; }

    public string? WuvaScOu { get; set; }

    public string? WunCcOu { get; set; }

    public string? WunScOu { get; set; }

    public string? WuvaTestUsed { get; set; }

    public short? WuiopAbute { get; set; }

    public short? WucvfAbute { get; set; }

    public string? WueomType { get; set; }

    public short? MedRecNotPerformed { get; set; }

    public short? WudilatedTimeZone { get; set; }

    public decimal? VitalsPulseOximetry { get; set; }

    public decimal? VitalsInhaled02Concentration { get; set; }

    public decimal? VitalsHofcpercentile { get; set; }

    public decimal? VitalsWflpercentile { get; set; }

    public decimal? VitalsBmipercentile { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedEmpId { get; set; }

    public DateTime? LastModified { get; set; }

    public int? LastModifiedEmpId { get; set; }

    public bool IntakeReconciled { get; set; }
}

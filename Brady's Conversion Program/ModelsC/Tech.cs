using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class Tech
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? OldVisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? Pmhfhother { get; set; }

    public string? Pmhsmoking { get; set; }

    public string? PmhsmokeHowMuch { get; set; }

    public string? PmhsmokeHowLong { get; set; }

    public string? PmhsmokeWhenQuit { get; set; }

    public string? Pmhalcohol { get; set; }

    public string? PmhalcoholHowMuch { get; set; }

    public string? Pmhdrugs { get; set; }

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

    public string? Wuvaccod { get; set; }

    public string? Wuvaccos { get; set; }

    public string? Wuvacctype { get; set; }

    public string? Wuvascod { get; set; }

    public string? Wuvascos { get; set; }

    public string? Wuvaphod { get; set; }

    public string? Wuvaphos { get; set; }

    public string? Wunccod { get; set; }

    public string? Wunccos { get; set; }

    public string? Wunscod { get; set; }

    public string? Wunscos { get; set; }

    public string? WudomEye { get; set; }

    public string? Wutcvfod { get; set; }

    public string? Wutcvfos { get; set; }

    public string? WucvfdiagOd { get; set; }

    public string? WucvfdiagOs { get; set; }

    public string? WueomsuTmOd { get; set; }

    public string? WueomsuNaOd { get; set; }

    public string? WueomtemporalOd { get; set; }

    public string? WueommedialOd { get; set; }

    public string? WueominTmOd { get; set; }

    public string? WueominNaOd { get; set; }

    public string? WueomsuNaOs { get; set; }

    public string? WueomsuTmOs { get; set; }

    public string? WueommedialOs { get; set; }

    public string? WueomtemporalOs { get; set; }

    public string? WueominNaOs { get; set; }

    public string? WueominTmOs { get; set; }

    public string? WupupilDarkSizeOd { get; set; }

    public string? WupupilLightSizeOd { get; set; }

    public string? WupupilReactionOd { get; set; }

    public string? WupupilShapeOd { get; set; }

    public string? WupupilApdod { get; set; }

    public string? WupupilDarkSizeOs { get; set; }

    public string? WupupilLightSizeOs { get; set; }

    public string? WupupilReactionOs { get; set; }

    public string? WupupilShapeOs { get; set; }

    public string? WupupilApdos { get; set; }

    public string? Wuextorbits { get; set; }

    public string? Wuextlids { get; set; }

    public string? Wuextpan { get; set; }

    public string? Wumood { get; set; }

    public string? WuorientPerson { get; set; }

    public string? WuorientPlace { get; set; }

    public string? WuorientSituation { get; set; }

    public string? WuorientTime { get; set; }

    public string? Wudilated { get; set; }

    public string? WudilatedTime { get; set; }

    public string? WudilatedEye { get; set; }

    public string? WudilatedAgent { get; set; }

    public string? WudilatedFrequency { get; set; }

    public string? Wunotes { get; set; }

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

    public string? HistoryMdreviewed { get; set; }

    public string? HistoryMdreviewedDate { get; set; }

    public string? HistoryMdreviewedEmpId { get; set; }

    public string? WorkupMdreviewed { get; set; }

    public string? WorkupMdreviewedDate { get; set; }

    public string? WorkupMdreviewedEmpId { get; set; }

    public string? PmhsmokingStatus { get; set; }

    public string? Wuvaccou { get; set; }

    public string? Wuvascou { get; set; }

    public string? Wunccou { get; set; }

    public string? Wunscou { get; set; }

    public string? WuvatestUsed { get; set; }

    public string? Wuiopabute { get; set; }

    public string? Wucvfabute { get; set; }

    public string? Wueomtype { get; set; }

    public string? MedRecNotPerformed { get; set; }

    public string? WudilatedTimeZone { get; set; }

    public string? VitalsPulseOximetry { get; set; }

    public string? VitalsInhaled02Concentration { get; set; }

    public string? VitalsHofcpercentile { get; set; }

    public string? VitalsWflpercentile { get; set; }

    public string? VitalsBmipercentile { get; set; }

    public string? Created { get; set; }

    public string? CreatedEmpId { get; set; }

    public string? LasstModified { get; set; }

    public string? LastModifiedEmpId { get; set; }

    public string? IntakeReconciled { get; set; }

    public string? Active { get; set; }
}

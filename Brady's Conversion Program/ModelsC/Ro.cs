using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("ROS")]
public partial class Ro
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("ROSEyePrevSurg")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyePrevSurg { get; set; }

    [Column("ROSEyeContactLens")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeContactLens { get; set; }

    [Column("ROSEyePain")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyePain { get; set; }

    [Column("ROSEyeDblVision")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeDblVision { get; set; }

    [Column("ROSEyeGlaucoma")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeGlaucoma { get; set; }

    [Column("ROSEyeCataracts")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeCataracts { get; set; }

    [Column("ROSEyeMacDegen")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeMacDegen { get; set; }

    [Column("ROSEyeDryEyes")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeDryEyes { get; set; }

    [Column("ROSEyeCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RoseyeCustomDesc1 { get; set; }

    [Column("ROSEyeCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeCustomValue1 { get; set; }

    [Column("ROSEyeCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RoseyeCustomDesc2 { get; set; }

    [Column("ROSEyeCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeCustomValue2 { get; set; }

    [Column("ROSEyeCustomDesc3")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RoseyeCustomDesc3 { get; set; }

    [Column("ROSEyeCustomValue3")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeCustomValue3 { get; set; }

    [Column("ROSEyeCustomDesc4")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RoseyeCustomDesc4 { get; set; }

    [Column("ROSEyeCustomValue4")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoseyeCustomValue4 { get; set; }

    [Column("ROSENTHardHearing")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosenthardHearing { get; set; }

    [Column("ROSENTRingingEars")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosentringingEars { get; set; }

    [Column("ROSENTVertigo")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Rosentvertigo { get; set; }

    [Column("ROSENTCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosentcustomDesc1 { get; set; }

    [Column("ROSENTCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosentcustomValue1 { get; set; }

    [Column("ROSENTCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosentcustomDesc2 { get; set; }

    [Column("ROSENTCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosentcustomValue2 { get; set; }

    [Column("ROSCardioChestPain")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioChestPain { get; set; }

    [Column("ROSCardioDizziness")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioDizziness { get; set; }

    [Column("ROSCardioFainting")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioFainting { get; set; }

    [Column("ROSCardioShortBreath")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioShortBreath { get; set; }

    [Column("ROSCardioIrreHeartBeat")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioIrreHeartBeat { get; set; }

    [Column("ROSCardioDiffLyingFlat")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioDiffLyingFlat { get; set; }

    [Column("ROSCardioCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RoscardioCustomDesc1 { get; set; }

    [Column("ROSCardioCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioCustomValue1 { get; set; }

    [Column("ROSCardioCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RoscardioCustomDesc2 { get; set; }

    [Column("ROSCardioCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RoscardioCustomValue2 { get; set; }

    [Column("ROSRespCough")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosrespCough { get; set; }

    [Column("ROSRespCongestion")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosrespCongestion { get; set; }

    [Column("ROSRespWeezing")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosrespWeezing { get; set; }

    [Column("ROSRespAsthma")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosrespAsthma { get; set; }

    [Column("ROSRespCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosrespCustomDesc1 { get; set; }

    [Column("ROSRespCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosrespCustomValue1 { get; set; }

    [Column("ROSRespCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosrespCustomDesc2 { get; set; }

    [Column("ROSRespCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosrespCustomValue2 { get; set; }

    [Column("ROSGasHeartBurn")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosgasHeartBurn { get; set; }

    [Column("ROSGasNausea")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosgasNausea { get; set; }

    [Column("ROSGasJaundiceHepa")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosgasJaundiceHepa { get; set; }

    [Column("ROSGasCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosgasCustomDesc1 { get; set; }

    [Column("ROSGasCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosgasCustomValue1 { get; set; }

    [Column("ROSGasCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosgasCustomDesc2 { get; set; }

    [Column("ROSGasCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosgasCustomValue2 { get; set; }

    [Column("ROSUrinaryPainDifficulty")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosurinaryPainDifficulty { get; set; }

    [Column("ROSUrinaryBloodIn")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosurinaryBloodIn { get; set; }

    [Column("ROSUrinaryKidneyStones")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosurinaryKidneyStones { get; set; }

    [Column("ROSUrinarySTD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosurinaryStd { get; set; }

    [Column("ROSUrinaryCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosurinaryCustomDesc1 { get; set; }

    [Column("ROSUrinaryCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosurinaryCustomValue1 { get; set; }

    [Column("ROSUrinaryCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosurinaryCustomDesc2 { get; set; }

    [Column("ROSUrinaryCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosurinaryCustomValue2 { get; set; }

    [Column("ROSPsycAnxiety")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RospsycAnxiety { get; set; }

    [Column("ROSPsycMoodSwings")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RospsycMoodSwings { get; set; }

    [Column("ROSPsycDiffSleeping")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RospsycDiffSleeping { get; set; }

    [Column("ROSPsycCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RospsycCustomDesc1 { get; set; }

    [Column("ROSPsycCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RospsycCustomValue1 { get; set; }

    [Column("ROSPsycCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RospsycCustomDesc2 { get; set; }

    [Column("ROSPsycCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RospsycCustomValue2 { get; set; }

    [Column("ROSBloodEasyBruise")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosbloodEasyBruise { get; set; }

    [Column("ROSBloodGumsBleed")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosbloodGumsBleed { get; set; }

    [Column("ROSBloodProlongedBleed")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosbloodProlongedBleed { get; set; }

    [Column("ROSBloodHeavyAsprin")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosbloodHeavyAsprin { get; set; }

    [Column("ROSBloodCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosbloodCustomDesc1 { get; set; }

    [Column("ROSBloodCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosbloodCustomValue1 { get; set; }

    [Column("ROSBloodCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosbloodCustomDesc2 { get; set; }

    [Column("ROSBloodCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosbloodCustomValue2 { get; set; }

    [Column("ROSMusSkeStiffness")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosmusSkeStiffness { get; set; }

    [Column("ROSMusSkeArthritis")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosmusSkeArthritis { get; set; }

    [Column("ROSMusSkeJointPain")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosmusSkeJointPain { get; set; }

    [Column("ROSMusSkeCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosmusSkeCustomDesc1 { get; set; }

    [Column("ROSMusSkeCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosmusSkeCustomValue1 { get; set; }

    [Column("ROSMusSkeCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosmusSkeCustomDesc2 { get; set; }

    [Column("ROSMusSkeCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosmusSkeCustomValue2 { get; set; }

    [Column("ROSSkinRashSores")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosskinRashSores { get; set; }

    [Column("ROSSkinLesions")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosskinLesions { get; set; }

    [Column("ROSSkinHivesEczema")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosskinHivesEczema { get; set; }

    [Column("ROSSkinCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosskinCustomDesc1 { get; set; }

    [Column("ROSSkinCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosskinCustomValue1 { get; set; }

    [Column("ROSSkinCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosskinCustomDesc2 { get; set; }

    [Column("ROSSkinCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosskinCustomValue2 { get; set; }

    [Column("ROSNeuroSeizures")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosneuroSeizures { get; set; }

    [Column("ROSNeuroWeakParalysis")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosneuroWeakParalysis { get; set; }

    [Column("ROSNeuroNumbness")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosneuroNumbness { get; set; }

    [Column("ROSNeuroTremors")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosneuroTremors { get; set; }

    [Column("ROSNeuroCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosneuroCustomDesc1 { get; set; }

    [Column("ROSNeuroCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosneuroCustomValue1 { get; set; }

    [Column("ROSNeuroCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosneuroCustomDesc2 { get; set; }

    [Column("ROSNeuroCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosneuroCustomValue2 { get; set; }

    [Column("ROSConsFatigue")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosconsFatigue { get; set; }

    [Column("ROSConsFever")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosconsFever { get; set; }

    [Column("ROSConsWeightGainLoss")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosconsWeightGainLoss { get; set; }

    [Column("ROSConsCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosconsCustomDesc1 { get; set; }

    [Column("ROSConsCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosconsCustomDesc2 { get; set; }

    [Column("ROSConsCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosconsCustomValue1 { get; set; }

    [Column("ROSConsCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosconsCustomValue2 { get; set; }

    [Column("ROSEndoThirst")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoThirst { get; set; }

    [Column("ROSEndoHunger")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoHunger { get; set; }

    [Column("ROSEndoUrination")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoUrination { get; set; }

    [Column("ROSEndoSweating")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoSweating { get; set; }

    [Column("ROSEndoNailChanges")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoNailChanges { get; set; }

    [Column("ROSEndoCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosendoCustomDesc1 { get; set; }

    [Column("ROSEndoCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosendoCustomDesc2 { get; set; }

    [Column("ROSEndoCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoCustomValue1 { get; set; }

    [Column("ROSEndoCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosendoCustomValue2 { get; set; }

    [Column("ROSImmuHives")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosimmuHives { get; set; }

    [Column("ROSImmuItching")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosimmuItching { get; set; }

    [Column("ROSImmuRunnyNose")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosimmuRunnyNose { get; set; }

    [Column("ROSImmuSinusPressure")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosimmuSinusPressure { get; set; }

    [Column("ROSImmuCustomDesc1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosimmuCustomDesc1 { get; set; }

    [Column("ROSImmuCustomDesc2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RosimmuCustomDesc2 { get; set; }

    [Column("ROSImmuCustomValue1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosimmuCustomValue1 { get; set; }

    [Column("ROSImmuCustomValue2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RosimmuCustomValue2 { get; set; }

    [Column("ROSNotes")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Rosnotes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

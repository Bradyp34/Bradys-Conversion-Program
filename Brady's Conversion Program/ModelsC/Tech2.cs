using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("tech2")]
public partial class Tech2
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

    [Column("WU2VAORxOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2vaorxOd { get; set; }

    [Column("WU2VAORxOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2vaorxOs { get; set; }

    [Column("WU2KMaxOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kmaxOd { get; set; }

    [Column("WU2KMaxDegOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kmaxDegOd { get; set; }

    [Column("WU2KMinOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kminOd { get; set; }

    [Column("WU2KMinDegOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kminDegOd { get; set; }

    [Column("WU2KMaxOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kmaxOs { get; set; }

    [Column("WU2KMaxDegOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kmaxDegOs { get; set; }

    [Column("WU2KMinOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kminOs { get; set; }

    [Column("WU2KMinDegOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2kminDegOs { get; set; }

    [Column("WU2TTVOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2ttvod { get; set; }

    [Column("WU2TTVOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2ttvos { get; set; }

    [Column("WU2TTVType")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2ttvtype { get; set; }

    [Column("WU2Custom1Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom1Desc { get; set; }

    [Column("WU2Custom1Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom1Data { get; set; }

    [Column("WU2Custom2Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom2Desc { get; set; }

    [Column("WU2Custom2Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom2Data { get; set; }

    [Column("WU2Custom3Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom3Desc { get; set; }

    [Column("WU2Custom3Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom3Data { get; set; }

    [Column("WU2Custom4Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom4Desc { get; set; }

    [Column("WU2Custom4Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom4Data { get; set; }

    [Column("WU2Custom5Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom5Desc { get; set; }

    [Column("WU2Custom5Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom5Data { get; set; }

    [Column("WU2Custom6Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom6Desc { get; set; }

    [Column("WU2Custom6Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom6Data { get; set; }

    [Column("WU2Custom7Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom7Desc { get; set; }

    [Column("WU2Custom7Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom7Data { get; set; }

    [Column("WU2Custom8Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom8Desc { get; set; }

    [Column("WU2Custom8Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom8Data { get; set; }

    [Column("WU2Custom9Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom9Desc { get; set; }

    [Column("WU2Custom9Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom9Data { get; set; }

    [Column("WU2Custom10Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom10Desc { get; set; }

    [Column("WU2Custom10Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom10Data { get; set; }

    [Column("WU2Custom11Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom11Desc { get; set; }

    [Column("WU2Custom11Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom11Data { get; set; }

    [Column("WU2Custom12Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom12Desc { get; set; }

    [Column("WU2Custom12Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom12Data { get; set; }

    [Column("WU2Custom13Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom13Desc { get; set; }

    [Column("WU2Custom13Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom13Data { get; set; }

    [Column("WU2Custom14Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom14Desc { get; set; }

    [Column("WU2Custom14Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom14Data { get; set; }

    [Column("WU2Custom15Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom15Desc { get; set; }

    [Column("WU2Custom15Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom15Data { get; set; }

    [Column("WU2Custom16Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom16Desc { get; set; }

    [Column("WU2Custom16Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom16Data { get; set; }

    [Column("WU2Custom17Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom17Desc { get; set; }

    [Column("WU2Custom17Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom17Data { get; set; }

    [Column("WU2Custom18Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom18Desc { get; set; }

    [Column("WU2Custom18Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom18Data { get; set; }

    [Column("WU2Custom19Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom19Desc { get; set; }

    [Column("WU2Custom19Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom19Data { get; set; }

    [Column("WU2Custom20Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom20Desc { get; set; }

    [Column("WU2Custom20Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom20Data { get; set; }

    [Column("WU2Custom21Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom21Desc { get; set; }

    [Column("WU2Custom21Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom21Data { get; set; }

    [Column("WU2Custom22Desc")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2custom22Desc { get; set; }

    [Column("WU2Custom22Data")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Wu2custom22Data { get; set; }

    [Column("WU2PachCCTOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2pachCctod { get; set; }

    [Column("WU2PachCCTOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2pachCctos { get; set; }

    [Column("WU2GlareLowOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareLowOd { get; set; }

    [Column("WU2GlareLowOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareLowOs { get; set; }

    [Column("WU2GlareMedOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareMedOd { get; set; }

    [Column("WU2GlareMedOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareMedOs { get; set; }

    [Column("WU2GlareHighOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareHighOd { get; set; }

    [Column("WU2GlareHighOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareHighOs { get; set; }

    [Column("WU2GlareType")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2glareType { get; set; }

    [Column("WU2VAPAMOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2vapamod { get; set; }

    [Column("WU2VAPAMOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2vapamos { get; set; }

    [Column("WU2KType")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Wu2ktype { get; set; }

    [Column("WU2HertelBase")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Wu2hertelBase { get; set; }

    [Column("WU2HertelOD")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Wu2hertelOd { get; set; }

    [Column("WU2HertelOS")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Wu2hertelOs { get; set; }

    [Column("WU2TearOsmolarityOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2tearOsmolarityOd { get; set; }

    [Column("WU2TearOsmolarityOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Wu2tearOsmolarityOs { get; set; }

    [Column("WU2TearOsmolarityCollectionDifficult")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Wu2tearOsmolarityCollectionDifficult { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

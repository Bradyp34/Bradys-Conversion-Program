using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("Refraction")]
public partial class Refraction
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

    [StringLength(20)]
    [Unicode(false)]
    public string? RefractionClass { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? RefractionType { get; set; }

    [Column("SphereOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SphereOd { get; set; }

    [Column("SphereOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SphereOs { get; set; }

    [Column("CylinderOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CylinderOd { get; set; }

    [Column("CylinderOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CylinderOs { get; set; }

    [Column("AxisOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? AxisOd { get; set; }

    [Column("AxisOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? AxisOs { get; set; }

    [Column("BifocalAddOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? BifocalAddOd { get; set; }

    [Column("BifocalAddOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? BifocalAddOs { get; set; }

    [Column("PrismHorzOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PrismHorzOd { get; set; }

    [Column("PrismHorzOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PrismHorzOs { get; set; }

    [Column("PrismVertOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PrismVertOd { get; set; }

    [Column("PrismVertOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PrismVertOs { get; set; }

    [Column("Prism360OD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Prism360Od { get; set; }

    [Column("Prism360OS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Prism360Os { get; set; }

    [Column("DirectionHOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DirectionHod { get; set; }

    [Column("DirectionHOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DirectionHos { get; set; }

    [Column("DirectionVOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DirectionVod { get; set; }

    [Column("DirectionVOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DirectionVos { get; set; }

    [Column("PDDistOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PddistOd { get; set; }

    [Column("PDDistOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PddistOs { get; set; }

    [Column("PDNearOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PdnearOd { get; set; }

    [Column("PDNearOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PdnearOs { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Age { get; set; }

    [Column("VaDOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaDod { get; set; }

    [Column("VaDOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaDos { get; set; }

    [Column("VaDOU")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaDou { get; set; }

    [Column("VaNOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaNod { get; set; }

    [Column("VaNOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaNos { get; set; }

    [Column("VaNOU")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaNou { get; set; }

    [Column("VaIOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaIod { get; set; }

    [Column("VaIOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaIos { get; set; }

    [Column("VaIOU")]
    [StringLength(20)]
    [Unicode(false)]
    public string? VaIou { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Expires { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

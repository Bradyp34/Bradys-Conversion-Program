using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class ContactLen
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

    [Column("RxID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RxId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ContactClass { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LensType { get; set; }

    [Column("PowerOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PowerOd { get; set; }

    [Column("PowerOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PowerOs { get; set; }

    [Column("CylinderOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CylinderOd { get; set; }

    [Column("CylinderOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CylinderOs { get; set; }

    [Column("AxisOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AxisOd { get; set; }

    [Column("AxisOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AxisOs { get; set; }

    [Column("BCOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Bcod { get; set; }

    [Column("BCOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Bcos { get; set; }

    [Column("AddOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AddOd { get; set; }

    [Column("AddOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AddOs { get; set; }

    [Column("ColorOD")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ColorOd { get; set; }

    [Column("ColorOS")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ColorOs { get; set; }

    [Column("PupilOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PupilOd { get; set; }

    [Column("PupilOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PupilOs { get; set; }

    [Column("VaDOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaDod { get; set; }

    [Column("VaDOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaDos { get; set; }

    [Column("VaDOU")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaDou { get; set; }

    [Column("VaNOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaNod { get; set; }

    [Column("VaNOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaNos { get; set; }

    [Column("VaNOU")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaNou { get; set; }

    [Column("VaIOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaIod { get; set; }

    [Column("VaIOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaIos { get; set; }

    [Column("VaIOU")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VaIou { get; set; }

    [Column("ComfortOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ComfortOd { get; set; }

    [Column("ComfortOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ComfortOs { get; set; }

    [Column("CentrationOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CentrationOd { get; set; }

    [Column("CentrationOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CentrationOs { get; set; }

    [Column("CoverageOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CoverageOd { get; set; }

    [Column("CoverageOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CoverageOs { get; set; }

    [Column("MovementOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MovementOd { get; set; }

    [Column("MovementOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MovementOs { get; set; }

    [Column("DiameterOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DiameterOd { get; set; }

    [Column("DiameterOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DiameterOs { get; set; }

    [Column("RotationDegOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RotationDegOd { get; set; }

    [Column("RotationDegOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RotationDegOs { get; set; }

    [Column("RotationDirectionOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RotationDirectionOd { get; set; }

    [Column("RotationDirectionOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RotationDirectionOs { get; set; }

    [Column("KOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Kod { get; set; }

    [Column("KOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Kos { get; set; }

    [Column("EdgeLiftOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EdgeLiftOd { get; set; }

    [Column("EdgeLiftOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EdgeLiftOs { get; set; }

    [Column("DistNearOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DistNearOd { get; set; }

    [Column("DistNearOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DistNearOs { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PtInsertedRemoved { get; set; }

    [Column("WAgeOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WageOd { get; set; }

    [Column("WAgeOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? WageOs { get; set; }

    [Column("WTimeTodayOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? WtimeTodayOd { get; set; }

    [Column("WTimeTodayOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? WtimeTodayOs { get; set; }

    [Column("WAvgWearTimeOD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? WavgWearTimeOd { get; set; }

    [Column("WAvgWearTimeOS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? WavgWearTimeOs { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Solution { get; set; }

    [Column("ProductOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductOd { get; set; }

    [Column("ProductOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ProductOs { get; set; }

    [Column("LensDesignOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LensDesignOd { get; set; }

    [Column("LensDesignOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LensDesignOs { get; set; }

    [Column("MaterialOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MaterialOd { get; set; }

    [Column("MaterialOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MaterialOs { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ReplacementSchedule { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? WearingInstructions { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Expires { get; set; }

    [Column("RGPLayoutOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RgplayoutOd { get; set; }

    [Column("RGPLayoutOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? RgplayoutOs { get; set; }

    [Column("Power2OD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Power2Od { get; set; }

    [Column("Power2OS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Power2Os { get; set; }

    [Column("Cylinder2OD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Cylinder2Od { get; set; }

    [Column("Cylinder2OS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Cylinder2Os { get; set; }

    [Column("Axis2OD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Axis2Od { get; set; }

    [Column("Axis2OS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Axis2Os { get; set; }

    [Column("BC2OD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Bc2od { get; set; }

    [Column("BC2OS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Bc2os { get; set; }

    [Column("Diameter2OD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Diameter2Od { get; set; }

    [Column("Diameter2OS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Diameter2Os { get; set; }

    [Column("PeriphCurveOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PeriphCurveOd { get; set; }

    [Column("PeriphCurveOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PeriphCurveOs { get; set; }

    [Column("PeriphCurve2OD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PeriphCurve2Od { get; set; }

    [Column("PeriphCurve2OS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PeriphCurve2Os { get; set; }

    [Column("SecondaryCurveOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? SecondaryCurveOd { get; set; }

    [Column("SecondaryCurveOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? SecondaryCurveOs { get; set; }

    [Column("EquivalentCurveOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EquivalentCurveOd { get; set; }

    [Column("EquivalentCurveOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EquivalentCurveOs { get; set; }

    [Column("CenterThicknessOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CenterThicknessOd { get; set; }

    [Column("CenterThicknessOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CenterThicknessOs { get; set; }

    [Column("OpticalZoneDiaOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OpticalZoneDiaOd { get; set; }

    [Column("OpticalZoneDiaOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OpticalZoneDiaOs { get; set; }

    [Column("EdgeOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EdgeOd { get; set; }

    [Column("EdgeOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EdgeOs { get; set; }

    [Column("BlendOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? BlendOd { get; set; }

    [Column("BlendOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? BlendOs { get; set; }

    [Column("NaFlPatternOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? NaFlPatternOd { get; set; }

    [Column("NaFlPatternOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? NaFlPatternOs { get; set; }

    [Column("SurfaceWettingOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SurfaceWettingOd { get; set; }

    [Column("SurfaceWettingOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SurfaceWettingOs { get; set; }

    [Column("DkOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DkOd { get; set; }

    [Column("DkOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DkOs { get; set; }

    [Column("SegHeightOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? SegHeightOd { get; set; }

    [Column("SegHeightOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? SegHeightOs { get; set; }

    [Column("SpecialInstructionsOD")]
    [StringLength(500)]
    [Unicode(false)]
    public string? SpecialInstructionsOd { get; set; }

    [Column("SpecialInstructionsOS")]
    [StringLength(500)]
    [Unicode(false)]
    public string? SpecialInstructionsOs { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Remarks { get; set; }

    [Column("UPCOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Upcod { get; set; }

    [Column("UPCOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Upcos { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogSource { get; set; }

    [Column("CatalogManufacturerIDOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogManufacturerIdod { get; set; }

    [Column("CatalogManufacturerIDOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogManufacturerIdos { get; set; }

    [Column("CatalogBrandIDOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogBrandIdod { get; set; }

    [Column("CatalogBrandIDOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogBrandIdos { get; set; }

    [Column("CatalogProductIDOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogProductIdod { get; set; }

    [Column("CatalogProductIDOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CatalogProductIdos { get; set; }

    [Column("ORSphereOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrsphereOd { get; set; }

    [Column("ORSphereOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrsphereOs { get; set; }

    [Column("ORCylinderOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrcylinderOd { get; set; }

    [Column("ORCylinderOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrcylinderOs { get; set; }

    [Column("ORAxisOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OraxisOd { get; set; }

    [Column("ORAxisOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OraxisOs { get; set; }

    [Column("ORVaDOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrvaDod { get; set; }

    [Column("ORVaDOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrvaDos { get; set; }

    [Column("ORVaNOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrvaNod { get; set; }

    [Column("ORVaNOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrvaNos { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TrialNumber { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

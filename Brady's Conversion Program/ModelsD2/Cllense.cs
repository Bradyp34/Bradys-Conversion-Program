using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

[Table("CLLenses")]
public partial class Cllense
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CLNDBrandID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ClndbrandId { get; set; }

    [Column("CLNSManufacturerID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ClnsmanufacturerId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Sphere { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Cylinder { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Axis { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? BaseCurve { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Diameter { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AddPower { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AddPowerName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Multifocal { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Color { get; set; }

    [Column("UPC")]
    [StringLength(15)]
    [Unicode(false)]
    public string? Upc { get; set; }

    [Column("CLNSLensTypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ClnslensTypeId { get; set; }

    [Column("CptID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CptId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AddedDate { get; set; }

    [Column("AddedBY")]
    [StringLength(20)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? UpdatedBy { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsSoftContact { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? LensPerBox { get; set; }

    [Column("IsLensFromCLXCatalog")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IsLensFromClxcatalog { get; set; }
}

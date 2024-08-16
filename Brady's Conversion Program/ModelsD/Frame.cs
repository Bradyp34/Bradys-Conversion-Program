using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class Frame
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldFrameID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OldFrameId { get; set; }

    [Column("FPC")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Fpc { get; set; }

    [Column("UPC")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Upc { get; set; }

    [Column("StyleID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? StyleId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? StyleName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Eye { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Bridge { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Temple { get; set; }

    [Column("DBL")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dbl { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? A { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? B { get; set; }

    [Column("ED")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Ed { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Circumference { get; set; }

    [Column("EDAngle")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Edangle { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? FrontPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? HalfTemplesPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? TemplesPrice { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CompletePrice { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? StyleNew { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ChangedPrice { get; set; }

    [Column("SKU")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Sku { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? YearIntroduced { get; set; }

    [Column("ManufacturerID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ManufacturerId { get; set; }

    [Column("VendorID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VendorId { get; set; }

    [Column("BrandID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? BrandId { get; set; }

    [Column("CollectionID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CollectionId { get; set; }

    [Column("FrameCategoryID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FrameCategoryId { get; set; }

    [Column("FrameShapeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FrameShapeId { get; set; }

    [Column("MaterialID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MaterialId { get; set; }

    [Column("FrameMountID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FrameMountId { get; set; }

    [Column("FrameColorID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FrameColorId { get; set; }

    [Column("LensColorID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LensColorId { get; set; }

    [Column("GenderID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? GenderId { get; set; }

    [Column("CountryID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CountryId { get; set; }

    [Column("AgeGroupID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AgeGroupId { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [Column("CPTID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Cptid { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? DateAdded { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LastUpdated { get; set; }
}

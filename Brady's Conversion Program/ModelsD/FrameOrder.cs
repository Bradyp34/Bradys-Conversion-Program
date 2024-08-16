using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameOrder")]
public partial class FrameOrder
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldFrameOrderInfoID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldFrameOrderInfoId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Name { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MaterialId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? StatusId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CptId { get; set; }

    [Column("ETypId")]
    [StringLength(10)]
    [Unicode(false)]
    public string? EtypId { get; set; }

    [Column("FTypId")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FtypId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Color { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ManufacturerId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Eye { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Bridge { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? A { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? B { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Ed { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Dbl { get; set; }

    [Column("CSize")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Csize { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? TempleSize { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? TempleStyleId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Retail { get; set; }

    [Column("[InventoryId")]
    [StringLength(10)]
    [Unicode(false)]
    public string? InventoryId { get; set; }

    [Column("IsLMSFrame")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IsLmsframe { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

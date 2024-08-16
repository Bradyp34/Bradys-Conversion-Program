using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameMaterial")]
public partial class FrameMaterial
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldMaterialID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldMaterialId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MaterialName { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? MaterialDescription { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SortOrder { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }
}

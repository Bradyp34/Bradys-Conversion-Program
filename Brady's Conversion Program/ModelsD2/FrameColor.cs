using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

[Table("FrameColor")]
public partial class FrameColor
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldFrameColorID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldFrameColorId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ColorCode { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ColorDescription { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }
}

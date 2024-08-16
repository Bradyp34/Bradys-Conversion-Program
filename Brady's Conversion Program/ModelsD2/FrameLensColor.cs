using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

[Table("FrameLensColor")]
public partial class FrameLensColor
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldLensColorID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldLensColorId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ColorCode { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? ColorDescription { get; set; }

    [Column("StatusID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? StatusId { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

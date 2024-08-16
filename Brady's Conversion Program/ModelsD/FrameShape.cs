using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameShape")]
public partial class FrameShape
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldShapeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldShapeId { get; set; }

    [Column("FrameShape")]
    [StringLength(10)]
    [Unicode(false)]
    public string? FrameShape1 { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? ShapeDescription { get; set; }

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

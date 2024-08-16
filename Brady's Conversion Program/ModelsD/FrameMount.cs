using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameMount")]
public partial class FrameMount
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldFrameMountID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldFrameMountId { get; set; }

    [Column("FrameMount")]
    [StringLength(50)]
    [Unicode(false)]
    public string? FrameMount1 { get; set; }

    [StringLength(200)]
    [Unicode(false)]
    public string? MountDescription { get; set; }

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

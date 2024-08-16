using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

[Table("FrameTemple")]
public partial class FrameTemple
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldTempleID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldTempleId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? LabCode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

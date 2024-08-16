using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameStatus")]
public partial class FrameStatus
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldStatusID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldStatusId { get; set; }

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

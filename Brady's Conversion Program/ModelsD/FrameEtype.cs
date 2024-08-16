using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

[Table("FrameEType")]
public partial class FrameEtype
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldETypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldEtypeId { get; set; }

    [Column("EType")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Etype { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(25)]
    [Unicode(false)]
    public string? LabCode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

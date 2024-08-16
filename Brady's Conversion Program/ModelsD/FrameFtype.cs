using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameFType")]
public partial class FrameFtype
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldFTypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldFtypeId { get; set; }

    [Column("FType")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Ftype { get; set; }

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("SchedCode")]
public partial class SchedCode
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("SchedulingCodeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SchedulingCodeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [Column("TypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TypeId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsNoShow { get; set; }
}

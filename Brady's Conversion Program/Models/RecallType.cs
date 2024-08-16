using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("RecallType")]
public partial class RecallType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldRecallTypeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldRecallTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OldRecallTypeCode { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DefaultDuration { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }
}

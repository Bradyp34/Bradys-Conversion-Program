using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

public partial class ExamCondition
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(200)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Condition { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Eye { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ConditionValue { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Comment { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

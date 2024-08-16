using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("FamilyHistory")]
public partial class FamilyHistory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Relation { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Age { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("CodeICD9")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CodeIcd9 { get; set; }

    [Column("CodeICD10")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CodeIcd10 { get; set; }

    [Column("CodeSNOMED")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CodeSnomed { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Comments { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

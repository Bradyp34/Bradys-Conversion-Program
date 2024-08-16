using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("ProcDiagPool")]
public partial class ProcDiagPool
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

    [Column("VisitProcCodePoolID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VisitProcCodePoolId { get; set; }

    [Column("VisitDiagCodePoolID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VisitDiagCodePoolId { get; set; }

    [Column("RequestedProcedureID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RequestedProcedureId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

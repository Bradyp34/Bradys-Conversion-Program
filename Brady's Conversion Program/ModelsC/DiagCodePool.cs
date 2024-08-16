using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

[Keyless]
[Table("DiagCodePool")]
public partial class DiagCodePool
{
    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Unicode(false)]
    public string? DiagText { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Modifier { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SourceField { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Active { get; set; }

    [Column("CodeICD10")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CodeIcd10 { get; set; }

    [Column("CodeSNOMED")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CodeSnomed { get; set; }

    [Column("RequestedProcedureID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RequestedProcedureId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetMonth1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetDay1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetYear1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location2 { get; set; }

    [Column("Location2OnsetVisitID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Location2OnsetVisitId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetMonth2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetDay2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetYear2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IsResolved1 { get; set; }

    [Column("ResolvedVisitID1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedVisitId1 { get; set; }

    [Column("ResolvedRequestedProcedureID1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedRequestedProcedureId1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedDate1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ResolveType1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IsResolved2 { get; set; }

    [Column("ResolvedVisitID2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedVisitId2 { get; set; }

    [Column("ResolvedRequestedProcedureID2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedRequestedProcedureId2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedDate2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ResolveType2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DoNotReconcile { get; set; }
}

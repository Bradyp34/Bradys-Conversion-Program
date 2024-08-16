using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

[Table("MedicalHistory")]
public partial class MedicalHistory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("ControlID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ControlId { get; set; }

    [Column("OrigVisitMedicalHistoryID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrigVisitMedicalHistoryId { get; set; }

    [Column("OrigVisitDiagCodePoolID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrigVisitDiagCodePoolId { get; set; }

    [Column("OrigDOSDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OrigDosdate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Modifier { get; set; }

    [Column("CodeICD10")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CodeIcd10 { get; set; }

    [Column("CodeSNOMED")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CodeSnomed { get; set; }

    [Column("TypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Severity1 { get; set; }

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
    public string? Severity2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetMonth2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetDay2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OnsetYear2 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsResolved1 { get; set; }

    [Column("ResolvedVisitID1")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedVisitId1 { get; set; }

    [Column("ResolvedRequestedProcedureID1")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ResolvedRequestedProcedureId1 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ResolvedDate1 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ResolveType1 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsResolved2 { get; set; }

    [Column("ResolvedVisitID2")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ResolvedVisitId2 { get; set; }

    [Column("ResolvedRequestedProcedureID2")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ResolvedRequestedProcedureId2 { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ResolvedDate2 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ResolveType2 { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DoNotReconcile { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LastModified { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Created { get; set; }

    [Column("CreatedEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CreatedEmpId { get; set; }

    [Column("LastModifiedEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LastModifiedEmpId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

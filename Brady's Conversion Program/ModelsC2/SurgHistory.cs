using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("SurgHistory")]
public partial class SurgHistory
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

    [Column("OrigVisitSurgicalHistoryID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OrigVisitSurgicalHistoryId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? OrigVisitDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("TypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TypeId { get; set; }

    [Column("CodeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CodeId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Modifier { get; set; }

    [Column("CodeICD10")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CodeIcd10 { get; set; }

    [Column("CodeSNOMED")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CodeSnomed { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Location1 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcedureMonth1 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcedureDay1 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcedureYear1 { get; set; }

    [Column("PerformedbyEmpID1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PerformedbyEmpId1 { get; set; }

    [Column("PerformedbyRefProviderID1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PerformedbyRefProviderId1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PerformedbyFullName1 { get; set; }

    [Column("ComanageEmpID1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ComanageEmpId1 { get; set; }

    [Column("ComanageRefProviderID1")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ComanageRefProviderId1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ComanageFullName1 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Location2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ProcedureMonth2 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcedureDay2 { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcedureYear2 { get; set; }

    [Column("PerformedbyEmpID2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PerformedbyEmpId2 { get; set; }

    [Column("PerformedbyRefProviderID2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PerformedbyRefProviderId2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PerformedbyFullName2 { get; set; }

    [Column("ComanageEmpID2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ComanageEmpId2 { get; set; }

    [Column("ComanageRefProviderID2")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ComanageRefProviderId2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ComanageFullName2 { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DoNotReconcile { get; set; }

    [Column("PtDeviceID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PtDeviceId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

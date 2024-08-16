using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("ProcPool")]
public partial class ProcPool
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
    public string? ProcText { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Modifier { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OriginalModifier { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Location { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SourceField { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsBilled { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcLocationType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ProcDiagTestComponents { get; set; }

    [Column("NotPORelated")]
    [StringLength(10)]
    [Unicode(false)]
    public string? NotPorelated { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProcType { get; set; }

    [Column("BillMultiProcID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? BillMultiProcId { get; set; }

    [Column("BillMultiProcControlID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? BillMultiProcControlId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AdditionalModifier { get; set; }

    [Column("IsQR")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IsQr { get; set; }

    [Column("EyeMDQRNum")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EyeMdqrnum { get; set; }

    [Column("PQRSNum")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Pqrsnum { get; set; }

    [Column("NQFNum")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Nqfnum { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Numerator { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Denominator { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsHidden { get; set; }

    [Column("QRComponent")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Qrcomponent { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Units { get; set; }

    [Column("RequestedProcedureID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RequestedProcedureId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SentInVisit { get; set; }

    [Column("SourceRecordID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? SourceRecordId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? InitialPatientPopulation { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DenominatorExclusion { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DenominatorException { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? BillingOrder { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

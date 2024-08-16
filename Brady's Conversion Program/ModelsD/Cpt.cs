using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("CPTs")]
public partial class Cpt
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CptID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CptId { get; set; }

    [Column("CPT")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Cpt1 { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SortOrder { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Fee { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Taxable { get; set; }

    [Column("DepartmentID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DepartmentId { get; set; }

    [Column("TypeOfServiceID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TypeOfServiceId { get; set; }

    [Column("TaxTypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? TaxTypeId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? PrivateStatementDescription { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AlternateCode { get; set; }

    [Column("UseCLIANumber")]
    [StringLength(10)]
    [Unicode(false)]
    public string? UseClianumber { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Units { get; set; }

    [Column("NDCActive")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Ndcactive { get; set; }

    [Column("NDCCode")]
    [StringLength(11)]
    [Unicode(false)]
    public string? Ndccode { get; set; }

    [Column("NDCCost")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Ndccost { get; set; }

    [Column("NDCUnitsMeasurementId")]
    [StringLength(10)]
    [Unicode(false)]
    public string? NdcunitsMeasurementId { get; set; }

    [Column("NDCQuantity")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Ndcquantity { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AutoUpdateReferringProvider { get; set; }
}

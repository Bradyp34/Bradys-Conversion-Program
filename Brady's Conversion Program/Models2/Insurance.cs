using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Table("Insurance")]
public partial class Insurance
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OldInsCompanyId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsCompanyName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsuranceCompanyCode { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? InsCompanyAddress1 { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? InsCompanyAddress2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsCompanyCity { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InsCompanyState { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InsCompanyZip { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InsCompanyPhone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsCompanyEmail { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InsCompanyFax { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InsCompanyPayerId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsCompanyClaimType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsCompanyPolicyType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsCompanyCarrierType { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MedicalVision { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsCollections { get; set; }

    [Column("IsDMERC")]
    [StringLength(10)]
    [Unicode(false)]
    public string? IsDmerc { get; set; }
}

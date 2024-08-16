using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Table("PatientInsurance")]
public partial class PatientInsurance
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PrimaryID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PrimaryId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PrimaryFile { get; set; }

    [Column("OldPatientID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldPatientId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InsuranceCompanyCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Group { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Cert { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedicalVision { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Rank { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? StartDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? EndDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Copay { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Deductible { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Plan { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

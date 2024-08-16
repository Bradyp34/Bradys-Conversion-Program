using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("PolicyHolder")]
public partial class PolicyHolder
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientInsuranceID")]
    public int? PatientInsuranceId { get; set; }

    [Column("OldPolicyHolderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldPolicyHolderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("DOB")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dob { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Sex { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? MaritalStatus { get; set; }

    [Column("SSN")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Ssn { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Relationship { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedicalVision { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Rank { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Note { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

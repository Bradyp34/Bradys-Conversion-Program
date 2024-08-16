using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Table("Patient")]
public partial class Patient
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OldPatientAccountNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OldPatientAltAccountNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PatientChartNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PreferredName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Title { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Suffix { get; set; }

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

    [StringLength(50)]
    [Unicode(false)]
    public string? Race { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Ethnicity { get; set; }

    [Column("SSN")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Ssn { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LicenseNo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LicenseState { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedicareSecondaryCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedicareSecondaryNotes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Consent { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ConsentDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ReleaseOfInfo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NoticeOfPrivPractice { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NoticeOfPrivPracticeDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Deceased { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? DateOfDeath { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PatientReferralCode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PatientAssignedProviderCode { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LastExamDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastExamLocation { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastExamType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastExamProvider { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EmployerName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PreferredContact1 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PreferredContact2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PreferredContact3 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PreferredContact4 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PreferredContact5 { get; set; }
}

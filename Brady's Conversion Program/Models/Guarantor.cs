using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("Guarantor")]
public partial class Guarantor
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    public int PatientId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OldGuarantorAccount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Sex { get; set; }

    [Column("SSN")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Ssn { get; set; }

    [Column("DOB")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Dob { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MaritalStatus { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Relationship { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

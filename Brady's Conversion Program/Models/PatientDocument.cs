using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

public partial class PatientDocument
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    public int PatientId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DocumentImageType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DocumentDescription { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DocumentNotes { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FilePathName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PatientInsuranceCompany { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Date { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

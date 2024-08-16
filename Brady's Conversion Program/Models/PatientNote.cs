using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("PatientNote")]
public partial class PatientNote
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PatientId { get; set; }

    [Unicode(false)]
    public string? Note { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LastUpdated { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

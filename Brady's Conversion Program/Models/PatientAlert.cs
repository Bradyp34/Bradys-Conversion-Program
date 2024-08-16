using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("PatientAlert")]
public partial class PatientAlert
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PatientId { get; set; }

    [Unicode(false)]
    public string? AlertMessage { get; set; }

    [Column("PriorityID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? PriorityId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AlertCreatedDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AlertCreatedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AlertExpiryDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AlertFlash { get; set; }
}

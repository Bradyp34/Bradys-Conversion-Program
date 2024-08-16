using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("Recall")]
public partial class Recall
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    public int PatientId { get; set; }

    [Column("OldRecallID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldRecallId { get; set; }

    [Column("OldRecallTypeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldRecallTypeId { get; set; }

    [Column("OldResourceID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldResourceId { get; set; }

    [Column("OldBillingLocationID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldBillingLocationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RecallDate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

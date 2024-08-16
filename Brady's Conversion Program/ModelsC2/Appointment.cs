using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

public partial class Appointment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("OldApptID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldApptId { get; set; }

    [Column("ClientSoftwareApptID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ClientSoftwareApptId { get; set; }

    [Column("ApptLocationID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ApptLocationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ApptStatus { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? ApptStartTime { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ApptNotes { get; set; }

    [Column("ApptProviderEmpID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ApptProviderEmpId { get; set; }

    [Column("ApptHL7Status")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ApptHl7status { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IntakeStatus { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ApptType { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? ApptReason { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

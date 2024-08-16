using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models;

[Table("Appointment")]
public partial class Appointment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    public int? PatientId { get; set; }

    [Column("OldAppointmentID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldAppointmentId { get; set; }

    [Column("OldAppointmentTypeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldAppointmentTypeId { get; set; }

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
    public string? StartDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EndDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Duration { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Status { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CheckInDateTime { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TakeBackDateTime { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? CheckOutDateTime { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DateTimeCreated { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DateTimeUpdated { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [Column("PriorAppointmentID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PriorAppointmentId { get; set; }

    [Column("LinkedAppointmentID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? LinkedAppointmentId { get; set; }

    [Column("SchedulingCodeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SchedulingCodeId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? SchedulingCodeNotes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Confirmed { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Sequence { get; set; }

    [Column("RecallID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RecallId { get; set; }

    [Column("WaitingListID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? WaitingListId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RequestId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Active { get; set; }
}

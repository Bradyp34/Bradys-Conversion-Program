using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Table("AppointmentType")]
public partial class AppointmentType
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldAppointmentTypeID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldAppointmentTypeId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OldAppointmentTypeCode { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DefaultDuration { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CanSchedule { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PatientRequired { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsExamType { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class PatientNote
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("EmpID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? EmpId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Created { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

[Table("PlanNarrative")]
public partial class PlanNarrative
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("VisitDoctorID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitDoctorId { get; set; }

    [Column("VisitDiagCodePoolID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitDiagCodePoolId { get; set; }

    [Column("SNOMEDCode")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Snomedcode { get; set; }

    [Column("ICD10Code")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Icd10code { get; set; }

    [Column("ICD9Code")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Icd9code { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NarrativeHeader { get; set; }

    [Unicode(false)]
    public string? NarrativeText { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? NarrativeType { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DisplayOrder { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

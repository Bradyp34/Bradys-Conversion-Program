using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

public partial class Allergy
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

    [StringLength(250)]
    [Unicode(false)]
    public string? AllergyName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Severity { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Reaction { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Inactive { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? StartDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Created { get; set; }

    [Column("CreatedEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CreatedEmpId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

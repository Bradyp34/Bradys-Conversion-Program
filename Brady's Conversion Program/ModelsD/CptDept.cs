using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("CPTDept")]
public partial class Cptdept
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("DepartmentID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? DepartmentId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Code { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SortNumber { get; set; }
}

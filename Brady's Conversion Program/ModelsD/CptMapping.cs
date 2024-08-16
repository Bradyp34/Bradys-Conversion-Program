using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD2;

[Table("CPTMapping")]
public partial class Cptmapping
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? MappingId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? CptId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? GroupId { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

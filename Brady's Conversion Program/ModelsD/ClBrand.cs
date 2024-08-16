using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("CLBrands")]
public partial class Clbrand
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldCLNSBrandID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldClnsbrandId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BrandName { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? BrandCode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AddedBy { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AddedDate { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

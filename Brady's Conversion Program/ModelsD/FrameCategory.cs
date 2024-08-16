using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameCategory")]
public partial class FrameCategory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldCategoryID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldCategoryId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CategoryName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? CategoryDescription { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SortOrder { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }
}

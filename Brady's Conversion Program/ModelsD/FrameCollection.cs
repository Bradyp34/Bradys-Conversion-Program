using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsD;

[Table("FrameCollection")]
public partial class FrameCollection
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldCollectionID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? OldCollectionId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? CollectionName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }

    [Column("LocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LocationId { get; set; }
}

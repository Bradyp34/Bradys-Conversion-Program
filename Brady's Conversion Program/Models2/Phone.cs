using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Table("Phone")]
public partial class Phone
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PrimaryFileID")]
    public int PrimaryFileId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PrimaryFile { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Extension { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Type { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Note { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

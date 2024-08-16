using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Keyless]
[Table("Address")]
public partial class Address
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("PrimaryFileID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PrimaryFileId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PrimaryFile { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Address1 { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Address2 { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? State { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Zip { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? TypeOfAddress { get; set; }

    [Unicode(false)]
    public string? Note { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Active { get; set; }
}

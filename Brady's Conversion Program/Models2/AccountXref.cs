using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Keyless]
[Table("AccountXref")]
public partial class AccountXref
{
    [StringLength(50)]
    [Unicode(false)]
    public string? OldAccount { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? NewAccount { get; set; }
}

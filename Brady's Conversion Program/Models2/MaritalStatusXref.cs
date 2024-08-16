using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Keyless]
[Table("MaritalStatus_Xref")]
public partial class MaritalStatusXref
{
    [Unicode(false)]
    public string? MaritalStatus { get; set; }

    [Column("MSCode")]
    [Unicode(false)]
    public string? Mscode { get; set; }
}

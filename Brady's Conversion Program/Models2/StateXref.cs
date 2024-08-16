using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Keyless]
[Table("State_Xref")]
public partial class StateXref
{
    [Unicode(false)]
    public string? State { get; set; }

    [Unicode(false)]
    public string? StateCode { get; set; }
}

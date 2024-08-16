using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Keyless]
[Table("Relationship_Xref")]
public partial class RelationshipXref
{
    [Unicode(false)]
    public string? Relationship { get; set; }

    [Unicode(false)]
    public string? RelCode { get; set; }
}

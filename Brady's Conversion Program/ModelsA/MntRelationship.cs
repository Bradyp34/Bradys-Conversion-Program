using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntRelationship
{
    public short RelationshipId { get; set; }

    public string Relationship { get; set; } = null!;

    public string? RelationshipCode { get; set; }

    public bool Active { get; set; }
}

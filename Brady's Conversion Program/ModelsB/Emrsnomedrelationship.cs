using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrsnomedrelationship
{
    public int TableId { get; set; }

    public string? RelationshipId { get; set; }

    public string? ConceptId1 { get; set; }

    public string? RelationshipType { get; set; }

    public string? ConceptId2 { get; set; }

    public short? CharacteristicType { get; set; }

    public short? Refinability { get; set; }

    public int? RelationshipGroup { get; set; }
}

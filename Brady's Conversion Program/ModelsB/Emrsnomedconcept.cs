using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrsnomedconcept
{
    public int TableId { get; set; }

    public string? ConceptId { get; set; }

    public int? ConceptStatus { get; set; }

    public string? FullySpecifiedName { get; set; }

    public string? Ctv3id { get; set; }

    public string? Snomedid { get; set; }

    public short? IsPrimitive { get; set; }
}

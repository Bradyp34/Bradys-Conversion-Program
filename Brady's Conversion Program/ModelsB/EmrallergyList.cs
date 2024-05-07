using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrallergyList
{
    public int TableId { get; set; }

    public string? AllergyName { get; set; }

    public string? MappingId { get; set; }

    public string? ConceptId { get; set; }

    public string? Rxcui { get; set; }

    public string? Snomed { get; set; }

    public string? ConceptType { get; set; }
}

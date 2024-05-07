using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class TaxonomyCode
{
    public int TaxonomyId { get; set; }

    public string? SpecialtyCode { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? ProviderType { get; set; }

    public string? Classification { get; set; }

    public string? Specialization { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntSpeciality
{
    public short SpecialityId { get; set; }

    public string? SpecialityName { get; set; }

    public string? SpecialityCode { get; set; }

    public string? SpecialityDescription { get; set; }

    public string? TaxonomyCode { get; set; }

    public bool? IsActive { get; set; }
}

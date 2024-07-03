using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class ClBrand
{
    public int Id { get; set; }

    public string? ClnsBrandId { get; set; }

    public string? BrandName { get; set; }

    public string? BrandCode { get; set; }

    public string? AddedBy { get; set; }

    public string? AddedDate { get; set; }

    public string? LocationId { get; set; }

    public string? IsActive { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ClnsLensType
{
    public int ClnsLensTypeId { get; set; }

    public string? LensTypeName { get; set; }

    public string? LensTypeCode { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public long? LocationId { get; set; }

    public bool? IsActive { get; set; }
}

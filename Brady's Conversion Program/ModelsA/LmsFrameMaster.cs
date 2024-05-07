using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LmsFrameMaster
{
    public long LmsFrameMasterId { get; set; }

    public int LmsFrameManufacturerLabId { get; set; }

    public string? LmsFrameManufacturerName { get; set; }

    public int LmsFrameModelLabId { get; set; }

    public string? LmsFrameModelName { get; set; }

    public int? LmsFrameTypeLabId { get; set; }

    public string? LmsFrameTypeName { get; set; }

    public string? A { get; set; }

    public string? B { get; set; }

    public string? Bridge { get; set; }

    public int? FrameColorId { get; set; }

    public string? FrameColorName { get; set; }

    public string? FrameColorImageUrl { get; set; }

    public string? Dbl { get; set; }

    public string? Ed { get; set; }

    public string? EyeSize { get; set; }

    public int? FrameSizeLabId { get; set; }

    public string? FrameName { get; set; }

    public string? Temple { get; set; }

    public string? Upc { get; set; }

    public int? InStock { get; set; }

    public int? CptId { get; set; }

    public string? Cost { get; set; }

    public string? Wholesale { get; set; }

    public string? Retail { get; set; }
}

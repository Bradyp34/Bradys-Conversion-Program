using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class ImageXref
{
    public long ImageId { get; set; }

    public string? ImageTypeOld { get; set; }

    public long? FfpmImageSetting { get; set; }

    public long? EyeMdImageSetting { get; set; }

    public long? ImageCount { get; set; }
}

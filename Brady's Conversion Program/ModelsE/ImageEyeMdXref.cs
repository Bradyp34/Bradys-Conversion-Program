using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class ImageEyeMdXref
{
    public long ImageCatId { get; set; }

    public string? EyeMdImageCategory { get; set; }

    public long? EyeMdImageType { get; set; }

    public long? EyeMdDocumentClass { get; set; }

    public long? EyeMdControlId { get; set; }
}

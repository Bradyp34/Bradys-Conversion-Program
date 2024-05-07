using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrimagesImbedded
{
    public int ImbededImageId { get; set; }

    public int? ParentId { get; set; }

    public int? Itlevel { get; set; }

    public string? Description { get; set; }

    public string? Code { get; set; }

    public byte[]? Image { get; set; }

    public int? ImageSize { get; set; }

    public int? ControlId { get; set; }

    /// <summary>
    /// 1 = Background Image, 2 = Stamp
    /// </summary>
    public int? ImageType { get; set; }

    public short DoNotAddText { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public int? CodeId { get; set; }

    public string? DestField { get; set; }

    public short? IncludeInFastStamp { get; set; }

    public string? InsertGuid { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emricd10
{
    public int TableId { get; set; }

    public string? Description { get; set; }

    public string? Icd10code { get; set; }

    public short? IsHeader { get; set; }

    public short? HasLaterality { get; set; }

    public short? HasUleyelid { get; set; }

    public short? HasNonSpecificCondition { get; set; }

    public short? HasCareEpisode { get; set; }
}

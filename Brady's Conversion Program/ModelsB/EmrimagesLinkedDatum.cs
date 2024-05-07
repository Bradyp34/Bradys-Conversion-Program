using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrimagesLinkedDatum
{
    public int LinkedDataId { get; set; }

    public int? LinkedImageId { get; set; }

    public int? PtId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? Description { get; set; }

    public string? DataTypeId { get; set; }

    public string? Dicomtag { get; set; }

    public string? DataValue { get; set; }

    public string? InsertGuid { get; set; }
}

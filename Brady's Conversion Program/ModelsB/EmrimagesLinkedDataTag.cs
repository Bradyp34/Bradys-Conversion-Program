using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrimagesLinkedDataTag
{
    public int LinkedDataTagId { get; set; }

    public string? Description { get; set; }

    public string? DataTypeId { get; set; }

    public string? ModalityCode { get; set; }

    public string? Dicomtag { get; set; }
}

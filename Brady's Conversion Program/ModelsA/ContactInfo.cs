using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ContactInfo
{
    public long ContactId { get; set; }

    public string? HomePhone { get; set; }

    public string? WorkPhone { get; set; }

    public string? WorkExtension { get; set; }

    public string? CellPhone { get; set; }

    public string? Email { get; set; }

    public string? Fax { get; set; }

    public long LocationId { get; set; }
}

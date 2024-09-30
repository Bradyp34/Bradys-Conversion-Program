using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class Contact
{
    public int ContactId { get; set; }

    public string? Name { get; set; }

    public string? Position { get; set; }

    public string? Phone { get; set; }

    public string? Cell { get; set; }

    public string? Email { get; set; }

    public string? Hours { get; set; }

    public int? Priority { get; set; }

    public string? Notes { get; set; }
}

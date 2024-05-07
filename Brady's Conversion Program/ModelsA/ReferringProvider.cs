using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ReferringProvider
{
    public long RefProviderId { get; set; }

    public string? RefProviderCode { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public long? LocationId { get; set; }

    public bool? Active { get; set; }
}

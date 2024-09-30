using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsE;

public partial class Clinic
{
    public string LegalName { get; set; } = null!;

    public string? MarketingName { get; set; }

    public string? MainPhone { get; set; }

    public string? AfterHours { get; set; }

    public string? Fax { get; set; }

    public string? Cell { get; set; }

    public string? WhoseCell { get; set; }

    public string? FedId { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Email { get; set; }

    public string? WhoseEmail { get; set; }
}

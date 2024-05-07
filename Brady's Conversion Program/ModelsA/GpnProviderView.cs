using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnProviderView
{
    public int ProviderId { get; set; }

    public string? ProviderCode { get; set; }

    public string? FullName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public string? LastName { get; set; }

    public bool? IsActive { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string State { get; set; } = null!;

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }
}

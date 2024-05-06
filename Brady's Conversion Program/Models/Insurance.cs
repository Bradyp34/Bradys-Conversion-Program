using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class Insurance
{
    public int Id { get; set; }

    public string? InsCompanyId { get; set; }

    public string? InsCompanyName { get; set; }

    public string? InsCompanyCode { get; set; }

    public string? InsCompanyAddress1 { get; set; }

    public string? InsCompanyAddress2 { get; set; }

    public string? InsCompanyCity { get; set; }

    public string? InsCompanyState { get; set; }

    public string? InsCompanyZip { get; set; }

    public string? InsCompanyPhone { get; set; }

    public string? InsCompanyEmail { get; set; }

    public string? InsCompanyFax { get; set; }

    public string? InsCompanyPayerId { get; set; }

    public string? InsCompanyClaimType { get; set; }

    public string? InsCompanyPolicyType { get; set; }

    public string? InsCompanyCarrierType { get; set; }

    public string? MedicalVision { get; set; }

    public string? IsActive { get; set; }

    public string? IsCollections { get; set; }

    public string? IsDmerc { get; set; }
}

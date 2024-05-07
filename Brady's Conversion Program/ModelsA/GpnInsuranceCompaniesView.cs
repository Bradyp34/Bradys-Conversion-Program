using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnInsuranceCompaniesView
{
    public int InsCompanyId { get; set; }

    public string InsCompanyName { get; set; } = null!;

    public string InsCompanyCode { get; set; } = null!;

    public string? InsCompanyAddress1 { get; set; }

    public string? InsCompanyAddress2 { get; set; }

    public string? InsCompanyCity { get; set; }

    public string? InsCompanyState { get; set; }

    public int? InsCompanyCountryId { get; set; }

    public string? InsCompanyZip { get; set; }

    public string? InsCompanyPhone { get; set; }

    public string? InsCompanyEmail { get; set; }

    public string? InsCompanyWebsite { get; set; }

    public string? PmCode { get; set; }

    public string? InsCompanyPayerId { get; set; }

    public bool? IsActive { get; set; }

    public string? Responsibility { get; set; }

    public string PaymentTransactionCode { get; set; } = null!;

    public string AdjustmentTransactionCode { get; set; } = null!;

    public bool IsCompanyInsurance { get; set; }

    public bool IsCollectionsInsurance { get; set; }
}

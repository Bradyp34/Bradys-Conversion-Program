using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsInsuranceCmpTest
{
    public int InsCompanyId { get; set; }

    public string InsCompanyName { get; set; } = null!;

    public string InsCompanyCode { get; set; } = null!;

    public string? InsCompanyAddress1 { get; set; }

    public string? InsCompanyAddress2 { get; set; }

    public string? InsCompanyCity { get; set; }

    public int? InsCompanyStateId { get; set; }

    public int? InsCompanyCountryId { get; set; }

    public string? InsCompanyZip { get; set; }

    public string? InsCompanyPhone { get; set; }

    public string? InsCompanyEmail { get; set; }

    public string? InsCompanyWebsite { get; set; }

    public string? PmCode { get; set; }

    public string? InsCompanyPayerId { get; set; }

    public int? InsCompanyPayerTypeId { get; set; }

    public int? InsCompanyClaimTypeId { get; set; }

    public int? InsCompanyPolicyTypeId { get; set; }

    public int? InsCompanyCarrierTypeId { get; set; }

    public int? LastModifiedBy { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public bool? IsActive { get; set; }
}

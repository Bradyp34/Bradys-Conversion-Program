using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsInsuranceCompany
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

    public string? InsCompanyFax { get; set; }

    public int CategoryId { get; set; }

    public int ResponsibilityId { get; set; }

    public string PaymentTransaction { get; set; } = null!;

    public string AdjustmentTransaction { get; set; } = null!;

    public bool AcceptAssignment { get; set; }

    public bool PrintAsOtherInsurance { get; set; }

    public bool AllowEligibilityChecks { get; set; }

    public bool ElectornicEnabled { get; set; }

    public bool ApplyShiftLogic { get; set; }

    public bool PaperClaimsOnly { get; set; }

    public bool IsCompanyInsurance { get; set; }

    public bool IsCollectionsInsurance { get; set; }

    public bool IsDmercPlaceOfService { get; set; }
}

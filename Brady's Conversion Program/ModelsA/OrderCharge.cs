using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderCharge
{
    public long OrderChargeId { get; set; }

    public long OrderId { get; set; }

    public string? ChargeName { get; set; }

    public string ChargeDescription { get; set; } = null!;

    public string ChargeCptId { get; set; } = null!;

    public string ChargeModifier1 { get; set; } = null!;

    public string ChargeModifier2 { get; set; } = null!;

    public string ChargeModifier3 { get; set; } = null!;

    public string ChargeModifier4 { get; set; } = null!;

    public int ChargeUnits { get; set; }

    public string? ChargeCost { get; set; }

    public string? ChargeTotalCost { get; set; }

    public string ChargeInsurance { get; set; } = null!;

    public bool IsChargeAdditional { get; set; }

    public bool SendToPm { get; set; }

    public int? ChargeDiagnosisId1 { get; set; }

    public int? ChargeDiagnosisId2 { get; set; }

    public int? ChargeDiagnosisId3 { get; set; }

    public int? ChargeDiagnosisId4 { get; set; }

    public int? ChargeDiagnosisId5 { get; set; }

    public int? ChargeDiagnosisId6 { get; set; }

    public int? ChargeDiagnosisId7 { get; set; }

    public int? ChargeDiagnosisId8 { get; set; }

    public DateTime? DateOfService { get; set; }

    public DateTime? CauseDate { get; set; }

    public DateTime? AdmitDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    public string? ChargeNote { get; set; }

    public string? Cause { get; set; }

    public long? ProviderId { get; set; }

    public long? LocationId { get; set; }

    public long? ReferenceProviderId { get; set; }

    public long? EhrchargeId { get; set; }

    public bool? IsEhrcharge { get; set; }

    public bool? IsChargeTreatment { get; set; }

    public long? TreatmentId { get; set; }

    public bool? IsTaxable { get; set; }

    public bool? IsTaxCharge { get; set; }

    public bool? IsGiftCardCharge { get; set; }

    public int InsuranceId { get; set; }

    public int PlanId { get; set; }

    public decimal EstimatedInsurance { get; set; }

    public int TaxTypeId { get; set; }

    public int TaxListId { get; set; }

    public decimal Tax { get; set; }

    public bool? Deleted { get; set; }

    public DateTime? DeletedDateTime { get; set; }

    public string? DeletedUser { get; set; }

    public decimal Copay { get; set; }

    public decimal Applied { get; set; }

    public bool ProcessClaim { get; set; }

    public bool TaxOnTotalFee { get; set; }

    public bool TaxOnEstimatedPatientBalance { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime DateModified { get; set; }

    public string? Batch { get; set; }

    public DateOnly? OnsetOfCurrentIllness { get; set; }

    public DateOnly? InitialTreatmentDate { get; set; }

    public DateOnly? AcuteManifestationDate { get; set; }

    public DateOnly? DateOfAccident { get; set; }

    public DateOnly? HearingAndVisionRxdate { get; set; }

    public DateOnly? AssumedAndRelinquishedCareDate { get; set; }

    public DateOnly? DateOfFirstContact { get; set; }

    public string SeriveAuthExcepionCode { get; set; } = null!;

    public string MandatoryMedicareCrossoverIndicator { get; set; } = null!;

    public string ReferralNumber { get; set; } = null!;

    public string PriorAuthorizationNumber { get; set; } = null!;

    public string Clianumber { get; set; } = null!;

    public string ReferringCliafacilityIdentifier { get; set; } = null!;

    public string CarePlanOverSightNumber { get; set; } = null!;

    public string ImmunizationBatchNumber { get; set; } = null!;

    public decimal EstimatedPatientBalance { get; set; }

    public bool AcceptAssignment { get; set; }

    public DateOnly? PatientAgeingDate { get; set; }

    public DateOnly? InsuranceAgeingDate { get; set; }

    public bool DisablePackageRelatedInformation { get; set; }
}

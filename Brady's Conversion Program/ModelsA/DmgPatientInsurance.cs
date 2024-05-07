using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientInsurance
{
    public long PatientInsuranceId { get; set; }

    public long? PatientId { get; set; }

    public long? SubscriberId { get; set; }

    public short? Rank { get; set; }

    public bool? IsSubscriberExistingPatient { get; set; }

    public short? RelationId { get; set; }

    public string? PolicyNumber { get; set; }

    public string? GroupId { get; set; }

    public int? InsuranceCompanyId { get; set; }

    public bool? InsurancePolicyType { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime? AddedTime { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? RemovedTime { get; set; }

    public long? RemovedBy { get; set; }

    public decimal? Copay { get; set; }

    public decimal? Deductible { get; set; }

    public bool? IsVerified { get; set; }

    public DateTime? VerificationDate { get; set; }

    public bool? AssignmentOfBenefits { get; set; }

    public DateTime? AssignmentOfBenefitsDate { get; set; }

    public int PlanId { get; set; }

    public bool IsMedicalInsurance { get; set; }

    public bool IsVisionInsurance { get; set; }

    public bool IsAdditionalInsurance { get; set; }

    public string? OldRecord { get; set; }
}

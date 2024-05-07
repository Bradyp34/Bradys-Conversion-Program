using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrpatient
{
    public int PtId { get; set; }

    public string? ClientSoftwarePtId { get; set; }

    public string? PatientChartNumber { get; set; }

    public string? PatientNameFirst { get; set; }

    public string? PatientNameLast { get; set; }

    public string? PatientNameMiddle { get; set; }

    public DateTime? PatientDob { get; set; }

    public string? PatientSex { get; set; }

    public string? PatientSsn { get; set; }

    public string? PatientGuardianNameFirst { get; set; }

    public string? PatientGuardianNameLast { get; set; }

    public string? PatientGuardianNameMiddle { get; set; }

    public DateTime? PatientGuardianDob { get; set; }

    public DateTime? PatientCreated { get; set; }

    public int? PatientEmpCreated { get; set; }

    public DateTime? PatientLastEdited { get; set; }

    public int? PatientEmpLastEdited { get; set; }

    public string? PatientAlert { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public string? PatientAddress { get; set; }

    public string? PatientAddress2 { get; set; }

    public string? PatientCity { get; set; }

    public string? PatientState { get; set; }

    public string? PatientZip { get; set; }

    public string? PatientInsPri { get; set; }

    public string? PatientInsPriId { get; set; }

    public string? PatientInsSec { get; set; }

    public string? PatientInsSecId { get; set; }

    public string? PatientHomePhone { get; set; }

    public string? PatientMobilePhone { get; set; }

    public string? PatientWorkPhone { get; set; }

    public string? PmimportCheckInNote { get; set; }

    public string? PatientFaxPhone { get; set; }

    public int? PatientDefaultRefProviderId { get; set; }

    public int? PatientDefaultPriProviderId { get; set; }

    public string? PatientNote { get; set; }

    public int? PatientDefaultEyeCareProviderId { get; set; }

    public string? PatientEmail { get; set; }

    public short? ErxSystemAccessed { get; set; }

    public string? PatientPreferredLanguage { get; set; }

    public string? PatientRace { get; set; }

    public string? PatientEthnicity { get; set; }

    public string? PatientPreferredContactMethod { get; set; }

    public short? PtDeceased { get; set; }

    public DateTime? PtDeceasedDate { get; set; }

    public short? CopyFromDefaultPatient { get; set; }

    public string? InsertGuid { get; set; }

    public string? PatientChartFilters { get; set; }

    public string? PatientMaritalStatus { get; set; }

    public short? WebportalOptOut { get; set; }

    public string? ClientSoftwarePtIdassignAuth { get; set; }

    public string? ClientSoftwarePtIdassignAuthIdtype { get; set; }

    public int? GenderIdentityId { get; set; }

    public string? GenderIdentityOtherDescription { get; set; }

    public string? GenderIdentityConceptCode { get; set; }

    public int? SexualOrientationId { get; set; }

    public string? SexualOrientationOtherDescription { get; set; }

    public string? SexualOrientationConceptCode { get; set; }

    public string? PatientNameSuffix { get; set; }

    public string? PatientPreviousAddress { get; set; }

    public string? PatientPreviousAddress2 { get; set; }

    public string? PatientPreviousCity { get; set; }

    public string? PatientPreviousState { get; set; }

    public string? PatientPreviousZip { get; set; }

    public DateTime? PatientDefaultRefProviderLastUpdated { get; set; }

    public string? InsuranceObject { get; set; }
}

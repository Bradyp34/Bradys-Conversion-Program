using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientAdditionalDetail
{
    public long PatientAdditionalDetailsId { get; set; }

    public long PatientId { get; set; }

    public bool? HippaConsent { get; set; }

    public DateTime? HippaConsentDate { get; set; }

    public bool? Npp { get; set; }

    public DateTime? NppDate { get; set; }

    public bool? IsStudent { get; set; }

    public bool? IsEmployed { get; set; }

    public string? EmployerName { get; set; }

    public long? EmployerAddressId { get; set; }

    public string? EmployerWebsite { get; set; }

    public int? OrganizationId { get; set; }

    public int? DefaultLocationId { get; set; }

    public int? RaceId { get; set; }

    public int? EthnicityId { get; set; }

    public int? PreferredLangaugeId { get; set; }

    public string? EmergencyFirst { get; set; }

    public string? EmergencyLast { get; set; }

    public long? EmergencyPatientId { get; set; }

    public int? EmergencyRelationId { get; set; }

    public long? EmergencyAddressId { get; set; }

    public bool? PreferredDoNotContact { get; set; }

    public short? PreferredContactFirstId { get; set; }

    public short? PreferredContactSecondId { get; set; }

    public short? PreferredContactThirdId { get; set; }

    public string? PreferredContactNotes { get; set; }

    public short? MedicareSecondaryId { get; set; }

    public string? MedicareSecondaryNotes { get; set; }

    public string? DriversLicenseNumber { get; set; }

    public short? DriversLicenseStateId { get; set; }

    public bool? DoNotContactAutomatedPhone { get; set; }

    public bool? DoNotContactHumanPhone { get; set; }

    public bool? DoNotContactEmail { get; set; }

    public bool? DoNotContactPostal { get; set; }
}

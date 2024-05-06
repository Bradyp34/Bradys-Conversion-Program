using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class Patient
{
    public int Id { get; set; }

    public string? PatientAccountNumber { get; set; }

    public string? PatientAltAccountNumber { get; set; }

    public string? PatientChartNumber { get; set; }

    public string? PatientFirst { get; set; }

    public string? PatientMiddle { get; set; }

    public string? PatientLast { get; set; }

    public string? PatientPreferredName { get; set; }

    public string? Title { get; set; }

    public string? Suffix { get; set; }

    public string? PatientDob { get; set; }

    public string? PatientSex { get; set; }

    public string? PatientMaritalStatus { get; set; }

    public string? PatientRace { get; set; }

    public string? PatientEthnicity { get; set; }

    public string? PatientSsn { get; set; }

    public string? PatientEmail { get; set; }

    public string? DriversLicense { get; set; }

    public string? DriversLicenseState { get; set; }

    public string? MedicareSecondaryCode { get; set; }

    public string? MedicareSecondaryNotes { get; set; }

    public string? Active { get; set; }

    public string? Consent { get; set; }

    public string? ConsentDate { get; set; }

    public string? ReleaseOfInfo { get; set; }

    public string? NoticeOfPrivPractice { get; set; }

    public string? NoticeOfPrivPracticeDate { get; set; }

    public string? DeceasedFlag { get; set; }

    public string? DateOfDeath { get; set; }

    public string? PatientReferralProviderCode { get; set; }

    public string? PatientAssignedProviderCode { get; set; }

    public string? LastExamDate { get; set; }

    public string? LastExamLocation { get; set; }

    public string? LastExamType { get; set; }

    public string? LastExamProvider { get; set; }

    public string? PatientPreferredContact1 { get; set; }

    public string? PatientPreferredContact2 { get; set; }

    public string? PatientPreferredContact3 { get; set; }

    public string? PatientPreferredContact4 { get; set; }

    public string? PatientPreferredContact5 { get; set; }
}

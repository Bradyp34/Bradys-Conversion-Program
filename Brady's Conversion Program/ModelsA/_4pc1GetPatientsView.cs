using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class _4pc1GetPatientsView
{
    public long PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly? Dob { get; set; }

    public string CellPhone { get; set; } = null!;

    public string WorkPhone { get; set; } = null!;

    public string HomePhone { get; set; } = null!;

    public string Address1 { get; set; } = null!;

    public string Address2 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Zip { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Ssn { get; set; } = null!;

    public string? Language { get; set; }

    public bool PreferredDoNotContact { get; set; }

    public string PatientCommunicationPreference1 { get; set; } = null!;

    public string PatientCommunicationPreference2 { get; set; } = null!;

    public string PatientCommunicationPreference3 { get; set; } = null!;

    public bool DoNotContactAutomatedPhone { get; set; }

    public bool DoNotContactHumanPhone { get; set; }

    public bool DoNotContactEmail { get; set; }

    public bool DoNotContactPostal { get; set; }

    public string Gender { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsDeceased { get; set; }

    public DateOnly? PatientLastExamDate { get; set; }

    public DateTime? PatientCreateDate { get; set; }

    public DateTime? PatientLastModifiedDate { get; set; }

    public int PatientProviderId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public int LastExamAppointmentTypeId { get; set; }

    public int LastExamBillingLocationId { get; set; }

    public int LastExamResourceId { get; set; }
}

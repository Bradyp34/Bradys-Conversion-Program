using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Patient
{
    public long PatientId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleInitial { get; set; }

    public DateTime? Dob { get; set; }

    public string? Title { get; set; }

    public string? Suffix { get; set; }

    public string? Ssn { get; set; }

    public DateTime? LastExamDate { get; set; }

    public bool? Hipaaconsent { get; set; }

    public DateTime? HipaaconsentDate { get; set; }

    public int? GenderId { get; set; }

    public int? MaritalStatusId { get; set; }

    public int? EmploymentStatusId { get; set; }

    public int? StudentStatusId { get; set; }

    public long? ReferredBy { get; set; }

    public long? GuarantorId { get; set; }

    public long CompanyId { get; set; }

    public long? AddressId { get; set; }

    public long? ContactId { get; set; }

    public string? EmrId { get; set; }

    public string? Employer { get; set; }

    public long? EmployerAddressId { get; set; }

    public int? StatusId { get; set; }
}

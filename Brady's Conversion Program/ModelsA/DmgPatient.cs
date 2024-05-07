using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatient
{
    public long PatientId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string? AltAccountNumber { get; set; }

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? PreferredName { get; set; }

    public string Ssn { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public short? MaritialStatusId { get; set; }

    public short? TitleId { get; set; }

    public short? SuffixId { get; set; }

    public short? GenderId { get; set; }

    public short? EmploymentStatusId { get; set; }

    public long? AddressId { get; set; }

    public int LocationId { get; set; }

    public int? UserId { get; set; }

    public int? AsssignedPhysicianId { get; set; }

    public int? ReferringProviderId { get; set; }

    public bool? AccountBalenceExists { get; set; }

    public DateTime? LastExamDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public int? LastModifiedBy { get; set; }

    public string? Status { get; set; }

    public bool? IsDeceased { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsMerge { get; set; }

    public bool? IsTestPatient { get; set; }

    public int? MergeDetailId { get; set; }

    public int? ConversionDetailId { get; set; }

    public bool? HasRemarks { get; set; }

    public bool? HasAlerts { get; set; }

    public bool? OnHold { get; set; }

    public decimal PatientBalance { get; set; }

    public decimal InsuranceBalance { get; set; }

    public decimal OtherBalance { get; set; }

    public DateTime BalanceLastUpdatedDateTime { get; set; }

    public DateOnly? DeceasedDate { get; set; }

    public bool EmailNotApplicable { get; set; }

    public bool DoNotSendStatements { get; set; }

    public bool EmailStatements { get; set; }

    public int? LastExamResourceId { get; set; }

    public int? LastExamBillingLocationId { get; set; }

    public int? LastExamAppointmentTypeId { get; set; }

    public int? LastExamStaffLocationId { get; set; }

    public DateTime? DateCreated { get; set; }

    public string OpenEdgeCustomerId { get; set; } = null!;

    public bool TextStatements { get; set; }
}

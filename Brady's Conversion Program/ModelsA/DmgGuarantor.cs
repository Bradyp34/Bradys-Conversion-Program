using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgGuarantor
{
    public long GuarantorId { get; set; }

    public long PatientId { get; set; }

    public bool? IsGuarantorExistingPatient { get; set; }

    public long? GuarantorExistingPatientId { get; set; }

    public short? RelationId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Ssn { get; set; }

    public DateTime? Dob { get; set; }

    public short? TitleId { get; set; }

    public short? SuffixId { get; set; }

    public long? AddressId { get; set; }

    public short? GenderId { get; set; }

    public short? EmploymentStatusId { get; set; }

    public DateTime? AddedDate { get; set; }

    public DateTime? RemovedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool? IsActive { get; set; }
}

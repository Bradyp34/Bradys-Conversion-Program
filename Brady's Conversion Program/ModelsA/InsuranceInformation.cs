using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InsuranceInformation
{
    public long InsuranceRecordId { get; set; }

    public long? PatientId { get; set; }

    public string? InsuranceCompany { get; set; }

    public string? InsuranceId { get; set; }

    public string? GroupId { get; set; }

    public string? RxgroupId { get; set; }

    public decimal? Copay { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Extension { get; set; }

    public string? FaxNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? Website { get; set; }

    public int? InsuranceOrder { get; set; }

    public long? AddressId { get; set; }

    public string? PayorId { get; set; }

    public bool? Active { get; set; }

    public string? InsuranceCode { get; set; }

    public int? LocationId { get; set; }
}

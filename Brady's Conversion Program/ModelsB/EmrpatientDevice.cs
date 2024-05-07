using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientDevice
{
    public int PtDeviceId { get; set; }

    public int PtId { get; set; }

    public string? UniversalIdentifier { get; set; }

    public string? DeviceIdentifier { get; set; }

    public string? IssuingAgency { get; set; }

    public string? Manufacturer { get; set; }

    public DateTime? ManufactureDate { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public string? LotNumber { get; set; }

    public string? SerialNumber { get; set; }

    /// <summary>
    /// Also known as &apos;distinct identifier&apos;
    /// </summary>
    public string? DonationIdentifier { get; set; }

    /// <summary>
    /// 0 = Unknown, 1 = Active, 2 = Inactive, 3 = Entered In Error
    /// </summary>
    public int? Status { get; set; }

    public string? BrandName { get; set; }

    public string? DeviceDescription { get; set; }

    public string? VersionModelNumber { get; set; }

    public string? Gmdnptname { get; set; }

    public string? Gmdnptdefinition { get; set; }

    public int? Snomedctcode { get; set; }

    public string? Snomedctdescription { get; set; }

    public string? MrisafetyInformation { get; set; }

    public short? LabeledContainsNrl { get; set; }

    public string? DeviceNotes { get; set; }

    public string? InsertGuid { get; set; }

    public string? DeviceName { get; set; }

    public DateTime? RecordedDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}

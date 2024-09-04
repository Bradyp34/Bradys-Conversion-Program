using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameManufacturer
{
    public long Id { get; set; }

    public string? OldManufacturerId { get; set; }

    public string? ManufacturerName { get; set; }

    public string? AccountNumber { get; set; }

    public string? AccountRep1 { get; set; }

    public string? AccountRep2 { get; set; }

    public string? AccountRep3 { get; set; }

    public string? AccountRep4 { get; set; }

    public string? Website { get; set; }

    public long LocationId { get; set; }

    public long? ContactId { get; set; }

    public long? AddressId { get; set; }

    public int? StatusId { get; set; }

    public bool? Contacts { get; set; }

    public bool? Frames { get; set; }

    public bool? Lenses { get; set; }

    public bool? Misc { get; set; }

    public bool? Active { get; set; }
}

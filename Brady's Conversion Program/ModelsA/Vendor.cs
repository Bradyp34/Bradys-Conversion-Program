using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Vendor
{
    public long VendorId { get; set; }

    public string? AccountNumber { get; set; }

    public string? VendorName { get; set; }

    public string? AccountRep1 { get; set; }

    public string? AccountRep2 { get; set; }

    public int? Discount { get; set; }

    public int? Terms { get; set; }

    public string? Website { get; set; }

    public long LocationId { get; set; }

    public long? ContactId { get; set; }

    public long? AddressId { get; set; }

    public long? ManufacturerId { get; set; }

    public int? StatusId { get; set; }
}

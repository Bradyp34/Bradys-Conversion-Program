using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntZipcode
{
    public int ZipCodeId { get; set; }

    public string? ZipCode { get; set; }

    public string? ZipCity { get; set; }

    public string? ZipStateCode { get; set; }

    public int? ZipStateId { get; set; }

    public string? ZipCounty { get; set; }

    public string? ZipLatitude { get; set; }

    public string? ZipLongitude { get; set; }

    public bool? IsActive { get; set; }
}

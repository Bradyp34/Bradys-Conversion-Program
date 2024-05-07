using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntAddressType
{
    public short AddressTypeId { get; set; }

    public string AddressTypeName { get; set; } = null!;

    public string? AddressTypeCode { get; set; }

    public bool IsActive { get; set; }
}

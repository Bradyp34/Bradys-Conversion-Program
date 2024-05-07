using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntMaritalStatus
{
    public short MaritalStatusId { get; set; }

    public string MaritalStatus { get; set; } = null!;

    public string? MaritalStatusCode { get; set; }

    public bool IsActive { get; set; }
}

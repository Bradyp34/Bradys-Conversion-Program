using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class MntEmploymentStatus
{
    public short EmploymentStatusId { get; set; }

    public string EmploymentStatus { get; set; } = null!;

    public string? EmploymentStatusCode { get; set; }

    public bool IsActive { get; set; }
}

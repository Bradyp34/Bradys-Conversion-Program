using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CptDepartment
{
    public int DepartmentId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int LocationId { get; set; }

    public bool Active { get; set; }

    public string SortNumber { get; set; } = null!;
}

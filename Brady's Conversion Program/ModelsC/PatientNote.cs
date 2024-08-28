using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class PatientNote
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? EmpId { get; set; }

    public string? Notes { get; set; }

    public string? Created { get; set; }

    public string? Active { get; set; }
}

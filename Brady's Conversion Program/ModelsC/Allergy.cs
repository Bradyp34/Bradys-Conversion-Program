using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class Allergy
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? AllergyName { get; set; }

    public string? Severity { get; set; }

    public string? Reaction { get; set; }

    public string? Inactive { get; set; }

    public string? StartDate { get; set; }

    public string? Created { get; set; }

    public string? CreatedEmpId { get; set; }

    public string? Active { get; set; }
}

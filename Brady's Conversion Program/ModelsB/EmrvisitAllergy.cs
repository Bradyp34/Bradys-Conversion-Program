using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitAllergy
{
    public int VisitAllergyId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? AllergyName { get; set; }

    public string? AllergyMappingId { get; set; }

    public string? AllergyConceptId { get; set; }

    public string? Severity { get; set; }

    public string? Reaction { get; set; }

    public short? Inactive { get; set; }

    public string? Snomedtype { get; set; }

    public string? Rxcui { get; set; }

    public string? Snomed { get; set; }

    public string? StartDate { get; set; }

    public string? InsertGuid { get; set; }

    public DateTime? LastModified { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedEmpId { get; set; }

    public int? LastModifiedEmpId { get; set; }
}

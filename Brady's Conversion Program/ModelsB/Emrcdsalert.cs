using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrcdsalert
{
    public int TableId { get; set; }

    public string? InterventionDescription { get; set; }

    public string? InterventionReference { get; set; }

    public string? InterventionFundingSource { get; set; }

    public int? InterventionRole { get; set; }

    public string? ProblemDescription { get; set; }

    public string? ProblemIcd9 { get; set; }

    public string? MedicationName { get; set; }

    public string? Allergy { get; set; }

    public string? PtRace { get; set; }

    public string? PtGender { get; set; }

    public int? PtAgeMin { get; set; }

    public int? PtAgeMax { get; set; }

    public int? PtWeightMin { get; set; }

    public int? PtWeightMax { get; set; }

    public int? PtBpsysMin { get; set; }

    public int? PtBpsysMax { get; set; }

    public int? PtIopmin { get; set; }

    public int? PtIopmax { get; set; }

    public string? LabTestName { get; set; }

    public string? LabTestOperator { get; set; }

    public string? LabTestValue { get; set; }

    public short? Active { get; set; }

    public string? ProblemIcd10 { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class FamilyHistory
{
    public int Id { get; set; }

    public int PtId { get; set; }

    public int? VisitId { get; set; }

    public string? Dosdate { get; set; }

    public string? Description { get; set; }

    public string? Relation { get; set; }

    public string? Age { get; set; }

    public string? Status { get; set; }

    public string? CodeIcd9 { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public string? Comments { get; set; }

    public string? Active { get; set; }
}

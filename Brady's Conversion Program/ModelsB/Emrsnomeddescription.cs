using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrsnomeddescription
{
    public int TableId { get; set; }

    public string? DescriptionId { get; set; }

    public int? DescriptionStatus { get; set; }

    public string? ConceptId { get; set; }

    public string? Term { get; set; }

    public short? InitialCapitalStatus { get; set; }

    public int? DescriptionType { get; set; }

    public string? LanguageCode { get; set; }
}

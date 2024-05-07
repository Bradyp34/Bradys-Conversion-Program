using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrdrugList
{
    public int TableId { get; set; }

    public string? DrugFullName { get; set; }

    public string? DrugStrength { get; set; }

    public string? DrugRoute { get; set; }

    public string? DrugForm { get; set; }

    public string? DrugMappingId { get; set; }

    public string? DrugAltMappingId { get; set; }

    public string? DrugName { get; set; }

    public string? DrugNameId { get; set; }

    public string? DrugBrandType { get; set; }

    public string? DrugFdastatus { get; set; }

    public string? DrugDeaclass { get; set; }

    public string? Snomed { get; set; }

    public string? Rxcui { get; set; }

    public string? Manufacturer { get; set; }
}

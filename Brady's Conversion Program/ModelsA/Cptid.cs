using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Cptid
{
    public int Cptid1 { get; set; }

    public string? Cpt { get; set; }

    public string? Description { get; set; }

    public int? SortOrder { get; set; }

    public bool? Active { get; set; }

    public long? LocationId { get; set; }

    public decimal? Fee { get; set; }

    public bool Taxable { get; set; }

    public int DepartmentId { get; set; }

    public int TypeOfServiceId { get; set; }

    public int TaxTypeId { get; set; }

    public string PrivateStatementDescription { get; set; } = null!;

    public string AlternateCode { get; set; } = null!;

    public bool UseClianumber { get; set; }

    public int Units { get; set; }

    public bool NdcActive { get; set; }

    public string? NdcCode { get; set; }

    public decimal? NdcCost { get; set; }

    public int? NdcUnitsMeasurementId { get; set; }

    public decimal? NdcQuantity { get; set; }

    public bool AutoUpdateReferringProvider { get; set; }
}

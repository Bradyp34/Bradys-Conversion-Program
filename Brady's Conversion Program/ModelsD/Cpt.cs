using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class Cpt
{
    public int Id { get; set; }

    public string? CptId { get; set; }

    public string? Cpt1 { get; set; }

    public string? Description { get; set; }

    public string? SortOrder { get; set; }

    public string? Active { get; set; }

    public string? LocationId { get; set; }

    public string? Fee { get; set; }

    public string? Taxable { get; set; }

    public string? DepartmentId { get; set; }

    public string? TypeOfServiceId { get; set; }

    public string? TaxTypeId { get; set; }

    public string? PrivateStatementDescription { get; set; }

    public string? AlternateCode { get; set; }

    public string? UseClianumber { get; set; }

    public string? Units { get; set; }

    public string? Ndcactive { get; set; }

    public string? Ndccode { get; set; }

    public string? Ndccost { get; set; }

    public string? NdcunitsMeasurementId { get; set; }

    public string? Ndcquantity { get; set; }

    public string? AutoUpdateReferringProvider { get; set; }
}

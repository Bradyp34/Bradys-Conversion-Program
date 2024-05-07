using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CurrentMonth20210118162803
{
    public long EventId { get; set; }

    public int BillingLocationId { get; set; }

    public int ProviderId { get; set; }

    public int InsuranceId { get; set; }

    public int? InsCategoryId { get; set; }

    public int? InsCompanyId { get; set; }

    public long ProcedureId { get; set; }

    public int? DepartmentId { get; set; }

    public int TransactionCodeId { get; set; }

    public int? TranCategoryId { get; set; }

    public int GroupId { get; set; }

    public int? LocationId { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Tax { get; set; }

    public int? Units { get; set; }

    public string EventCategory { get; set; } = null!;

    public long? RowNum { get; set; }
}

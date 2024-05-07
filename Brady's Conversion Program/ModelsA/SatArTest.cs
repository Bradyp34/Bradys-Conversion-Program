using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class SatArTest
{
    public long EventId { get; set; }

    public long? OrderChargeId { get; set; }

    public DateOnly? Pad { get; set; }

    public DateOnly? Iad { get; set; }

    public long EventSponsorId { get; set; }

    public string EventCategory { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public int InsuranceId { get; set; }

    public int ProviderId { get; set; }

    public int BillingLocationId { get; set; }

    public int ProcedureOrTransactionCodeId { get; set; }

    public int GroupId { get; set; }

    public decimal? Amount { get; set; }

    public decimal Tax { get; set; }

    public decimal EstimatedInsurance { get; set; }

    public decimal EstimatedPatientBalance { get; set; }

    public string? Responsibility { get; set; }

    public string? CDR { get; set; }

    public long? RowNum { get; set; }
}

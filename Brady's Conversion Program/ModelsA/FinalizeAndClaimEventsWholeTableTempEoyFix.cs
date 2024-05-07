using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class FinalizeAndClaimEventsWholeTableTempEoyFix
{
    public long EventId { get; set; }

    public long EventSponsorId { get; set; }

    public string EventCategory { get; set; } = null!;

    public string EventType { get; set; } = null!;

    public string Batch { get; set; } = null!;

    public int InsuranceId { get; set; }

    public int ProviderId { get; set; }

    public int BillingLocationId { get; set; }

    public DateOnly ServiceOrPaymentDate { get; set; }

    public int ProcedureOrTransactionCodeId { get; set; }

    public int GroupId { get; set; }

    public decimal Amount { get; set; }

    public decimal Tax { get; set; }

    public decimal EstimatedInsurance { get; set; }

    public decimal EstimatedPatientBalance { get; set; }

    public int EventStaffId { get; set; }

    public DateTime EventDateTime { get; set; }

    public bool? IsFinalized { get; set; }

    public DateTime? FinalizedDateTime { get; set; }

    public int? FinalizedStaffId { get; set; }

    public bool? IsClaimProcessed { get; set; }

    public DateTime? ClaimProcessedDateTime { get; set; }

    public int? ClaimProcessedStaffId { get; set; }

    public bool Active { get; set; }

    public string M1 { get; set; } = null!;

    public string M2 { get; set; } = null!;

    public string M3 { get; set; } = null!;

    public string M4 { get; set; } = null!;

    public string Diagnosis1 { get; set; } = null!;

    public string Diagnosis2 { get; set; } = null!;

    public string Diagnosis3 { get; set; } = null!;

    public string Diagnosis4 { get; set; } = null!;

    public long ProcedureId { get; set; }

    public int Units { get; set; }
}

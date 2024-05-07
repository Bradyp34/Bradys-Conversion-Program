using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitIndClmPayment
{
    public long EdiRemitIndClaimPaymentId { get; set; }

    public string? EdiRemitClaimPaymentClaimId { get; set; }

    public string? EdiRemitClaimPaymentStatus { get; set; }

    public string? EdiRemitIndClmBilledAmt { get; set; }

    public string? EdiRemitIndClmPaidAmt { get; set; }

    public string? EdiRemitIndClmPatRespAmt { get; set; }

    public string? EdiRemitIndClmClaimType { get; set; }

    public string? EdiRemitIndClmPayerCtrlNum { get; set; }

    public string? EdiRemitIndClmFacilityName { get; set; }

    public string? EdiRemitIndClmPatientName { get; set; }

    public string? EdiRemitIndClmPolicyNumber { get; set; }

    public string? EdiRemitIndClmInsuredName { get; set; }

    public string? EdiRemitIndClmCorrectedName { get; set; }

    public string? EdiRemitIndClmProviderName { get; set; }

    public string? EdiRemitIndClmCrossoverCarrier { get; set; }

    public DateTime? EdiRemitIndClmPmtDnyCovExpDate { get; set; }

    public DateTime? EdiRemitIndClmReceivedDate { get; set; }

    public string? EdiRemitIndClmCoveredAmt { get; set; }

    public string? EdiRemitIndClmInterestAmt { get; set; }

    public string? EdiRemitIndClmMonetaryAmt { get; set; }

    public long? EdiRemitFileId { get; set; }

    public string? EdiRemitTransactionId { get; set; }

    public bool? EdiRemitPmtIsClmSentFromSys { get; set; }

    public bool? EdiRemitClaimPaymentClaimIdUpdated { get; set; }
}

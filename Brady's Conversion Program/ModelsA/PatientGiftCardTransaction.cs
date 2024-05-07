using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PatientGiftCardTransaction
{
    public long GiftCardTransactionId { get; set; }

    public long GiftCardId { get; set; }

    public long PatientId { get; set; }

    public string? TransactionCode { get; set; }

    public string? TransactionCodeDesc { get; set; }

    public long? SecondaryGiftCardId { get; set; }

    public string? ResponseCode { get; set; }

    public string? ResponseCodeDesc { get; set; }

    public decimal? BeginningBalance { get; set; }

    public decimal? EndingBalance { get; set; }

    public decimal? ProcessedAmt { get; set; }

    public string? XgiftTransactionId { get; set; }

    public string? XgiftResponseString { get; set; }

    public string? XgiftRequestString { get; set; }

    public DateTime? TransactionDateTime { get; set; }

    public int? TransactionBy { get; set; }

    public string? XgiftReciptNo { get; set; }

    public string? XgiftReferenceNo { get; set; }

    public long? OrderId { get; set; }

    public string? GiftCardNotes { get; set; }
}

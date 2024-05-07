using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiRemitFile
{
    public long EdiRemitFileId { get; set; }

    public DateTime? EdiRemitFileReceivedDate { get; set; }

    public int? EdiRemitPaymentCount { get; set; }

    public string? EdiRemitTotalAmount { get; set; }

    public string? EdiRemitPayerName { get; set; }

    public string? EdiRemitPayerId { get; set; }

    public string? EdiRemitPayerAddress1 { get; set; }

    public string? EdiRemitPayerAddress2 { get; set; }

    public string? EdiRemitPayerCity { get; set; }

    public string? EdiRemitPayerState { get; set; }

    public string? EdiRemitPayerZip { get; set; }

    public string? EdiRemitContactPayerBusinessName { get; set; }

    public string? EdiRemitContactPayerBusinessPhone { get; set; }

    public string? EdiRemitContactPayerTechnicalName { get; set; }

    public string? EdiRemitContactPayerTechinicalPhone { get; set; }

    public string? EdiRemitPayerWebsite { get; set; }

    public string? EdiRemitPayeeName { get; set; }

    public string? EdiRemitPayeeAddress1 { get; set; }

    public string? EdiRemitPayeeAddress2 { get; set; }

    public string? EdiRemitPayeeCity { get; set; }

    public string? EdiRemitPayeeState { get; set; }

    public string? EdiRemitPayeeZip { get; set; }

    public string? EdiRemitPayeeId { get; set; }

    public string? EdiRemitControlNumber { get; set; }

    public string? EdiRemitHandlingType { get; set; }

    public string? EdiRemitMonetaryAmount { get; set; }

    public string? EdiRemitCreditOrDebit { get; set; }

    public string? EdiRemitPaymentMethod { get; set; }

    public string? EdiRemitCheckEftNumber { get; set; }

    public DateTime? EdiRemitIssueDate { get; set; }

    public DateTime? EdiRemitProdDate { get; set; }

    public string? EdiRemitFileName { get; set; }

    public string? EdiRemitFileContent { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsPosted { get; set; }
}

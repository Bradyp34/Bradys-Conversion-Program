using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeInforamation
{
    public int ProcessingAccountId { get; set; }

    public string ProcessingAccountType { get; set; } = null!;

    public string ProcessingAccountName { get; set; } = null!;

    public string XwebId { get; set; } = null!;

    public string XwebTerminalId { get; set; } = null!;

    public string XwebAuthKey { get; set; } = null!;

    public decimal MinimumAmountForSignature { get; set; }

    public bool Active { get; set; }

    public bool UseCreditCardAlias { get; set; }

    public bool SignatureRequiredOnPurchase { get; set; }

    public bool SignatureRequiredOnVoid { get; set; }

    public bool SignatureRequiredOnReturn { get; set; }

    public string ProcessingAccountNumber { get; set; } = null!;

    public string DonationNameOnPpd { get; set; } = null!;

    public bool HideReceiptSignatureBoxIfBlank { get; set; }

    public string AccountCredential { get; set; } = null!;
}

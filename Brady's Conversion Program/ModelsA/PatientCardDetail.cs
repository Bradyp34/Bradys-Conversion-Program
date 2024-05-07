using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PatientCardDetail
{
    public long PatientCardId { get; set; }

    public string CardNumber { get; set; } = null!;

    public string CardAddress { get; set; } = null!;

    public string CardZipCode { get; set; } = null!;

    public string? CardHolderName { get; set; }

    public string? XcaccountId { get; set; }

    public string? CardType { get; set; }

    public string? ExpirationDate { get; set; }

    public bool? IsCreditCard { get; set; }

    public bool? IsDebitCard { get; set; }

    public string PaymentType { get; set; } = null!;

    public string CheckAccountType { get; set; } = null!;

    public string CheckAccountNumber { get; set; } = null!;

    public string CheckRoutingNumber { get; set; } = null!;
}

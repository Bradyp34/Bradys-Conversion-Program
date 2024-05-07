using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PatientGiftCard
{
    public long GiftCardId { get; set; }

    public long PatientId { get; set; }

    public string? GiftCardAccountNo { get; set; }

    public decimal? IssuedAmmount { get; set; }

    public string? GiftCardOrderId { get; set; }

    public long? IssuedBy { get; set; }

    public string? TerminalId { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime? IssuedTime { get; set; }

    public bool? IsActive { get; set; }
}

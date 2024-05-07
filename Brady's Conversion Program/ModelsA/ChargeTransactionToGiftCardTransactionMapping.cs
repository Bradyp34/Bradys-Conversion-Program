using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargeTransactionToGiftCardTransactionMapping
{
    public long MappingId { get; set; }

    public long? ChargeTransactionId { get; set; }

    public long? GiftCardTransactionId { get; set; }

    public bool? IsDeleted { get; set; }
}

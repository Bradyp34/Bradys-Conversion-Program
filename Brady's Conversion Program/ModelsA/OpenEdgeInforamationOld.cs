using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeInforamationOld
{
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ProcessingAccountName { get; set; } = null!;

    public int LocationId { get; set; }

    public decimal MinimumAmountForSignature { get; set; }

    public bool SignatureRequiredOnPurchase { get; set; }

    public bool SignatureRequiredOnVoid { get; set; }

    public bool SignatureRequiredOnReturn { get; set; }
}

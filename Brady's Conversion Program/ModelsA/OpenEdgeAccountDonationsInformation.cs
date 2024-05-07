using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OpenEdgeAccountDonationsInformation
{
    public int Id { get; set; }

    public int ProcessingAccountId { get; set; }

    public decimal Amount { get; set; }
}

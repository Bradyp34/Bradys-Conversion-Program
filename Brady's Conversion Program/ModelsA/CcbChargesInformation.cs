using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class CcbChargesInformation
{
    public long Id { get; set; }

    public long OrderChargeId { get; set; }

    public DateTime ChargeAddedDateTime { get; set; }

    public bool? ChargeRemoved { get; set; }

    public DateTime? ChargeRemovedDateTime { get; set; }

    public bool? ChargeSentToCcb { get; set; }

    public bool FinalNoticeSent { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class XchargeUser
{
    public long XchargeUserId { get; set; }

    public string XchargeUserName { get; set; } = null!;

    public string XchargePassword { get; set; } = null!;

    public string XchargeProcessingAccountName { get; set; } = null!;

    public int LocationId { get; set; }
}

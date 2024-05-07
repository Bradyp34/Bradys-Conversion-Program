using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrempMultiFactorToken
{
    public int EmpMultiFactorTokenId { get; set; }

    public int EmpId { get; set; }

    public string PcuserName { get; set; } = null!;

    public string Pcname { get; set; } = null!;

    public string Token { get; set; } = null!;

    public DateTime IssuedOn { get; set; }

    public DateTime? VerifiedOn { get; set; }

    public string InsertGuid { get; set; } = null!;
}

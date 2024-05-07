using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ehrcharge
{
    public long EhrchargeId { get; set; }

    public long AccountNo { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Provider { get; set; }

    public bool? IsActive { get; set; }

    public long? LocationId { get; set; }

    public DateTime? DateOfService { get; set; }

    public string? ProcedureCodeAndDescription { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? DateReceived { get; set; }

    public string? Msh { get; set; }

    public string? Evn { get; set; }

    public string? Pid { get; set; }

    public string? Pv1 { get; set; }

    public string? Ft1 { get; set; }

    public string? Pr1 { get; set; }

    public string? Dg1 { get; set; }

    public bool IsEyeMdcharge { get; set; }

    public DateTime? DateModified { get; set; }
}

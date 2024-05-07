using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GetLocationInformationAndCountsView
{
    public string? Version { get; set; }

    public string? Fsgaccountingcode { get; set; }

    public string Locationname { get; set; } = null!;

    public string Companyname { get; set; } = null!;

    public int? TotalEhrCharges { get; set; }

    public int? TotalUnAttachedEhrCharges { get; set; }

    public int? TotalAppointments { get; set; }

    public int? TotalRecalls { get; set; }

    public int? TotalAppointmentsWithRecallsAttached { get; set; }

    public int? TotalPositiveBalanceDueOrders { get; set; }

    public int? TotalZeroBalanceDueOrders { get; set; }

    public string? Last4pcEventDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class Recall
{
    public int Id { get; set; }

    public string? RecallId { get; set; }

    public string? PatientId { get; set; }

    public string? RecallTypeId { get; set; }

    public string? ResourceId { get; set; }

    public string? BillingLocationId { get; set; }

    public string? RecallDate { get; set; }

    public string? Notes { get; set; }

    public string? Active { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class PatientAlert
{
    public int Id { get; set; }

    public string? PatientId { get; set; }

    public string? AlertMessage { get; set; }

    public string? PriorityId { get; set; }

    public string? AlertCreatedDate { get; set; }

    public string? AlertCreatedBy { get; set; }

    public string? AlertExpiryDate { get; set; }

    public string? IsActive { get; set; }

    public string? AlertFlash { get; set; }
}

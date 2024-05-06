using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.Models;

public partial class PatientNote
{
    public int Id { get; set; }

    public string? PatientId { get; set; }

    public string? Note { get; set; }

    public string? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public string? LastUpdated { get; set; }

    public string? IsActive { get; set; }
}

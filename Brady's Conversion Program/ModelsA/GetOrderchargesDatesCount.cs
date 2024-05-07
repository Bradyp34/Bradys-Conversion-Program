using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GetOrderchargesDatesCount
{
    public long PatientId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public long LabOrderId { get; set; }

    public string? ChargeName { get; set; }

    public string? Cause { get; set; }

    public DateTime? CauseDate { get; set; }

    public DateTime? AdmitDate { get; set; }

    public DateTime? DischargeDate { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwGetVwOrderDetail
{
    public long OrderId { get; set; }

    public string? PatientName { get; set; }

    public string? VwOrderId { get; set; }

    public DateTime? SentDate { get; set; }

    public string? SentStatus { get; set; }
}

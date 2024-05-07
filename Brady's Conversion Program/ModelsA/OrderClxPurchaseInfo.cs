using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderClxPurchaseInfo
{
    public long OrderClxPurchaseInfoId { get; set; }

    public long OrderId { get; set; }

    public string? PatientName { get; set; }

    public string? XmlRequestString { get; set; }

    public DateTime? SentTime { get; set; }

    public long? SentBy { get; set; }

    public string? XmlResponseString { get; set; }

    public string? Status { get; set; }

    public string? ClxOrderId { get; set; }
}

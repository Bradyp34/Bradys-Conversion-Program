using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwOrderDetail
{
    public long OrderDetailsId { get; set; }

    public long OrderId { get; set; }

    public string? OrderXmlString { get; set; }

    public string? PatientName { get; set; }

    public string? VwOrderId { get; set; }

    public string? VwExchangeId { get; set; }

    public string? SupplierName { get; set; }

    public DateTime? SentDate { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? SentStatus { get; set; }

    public string? SentOrderId { get; set; }
}

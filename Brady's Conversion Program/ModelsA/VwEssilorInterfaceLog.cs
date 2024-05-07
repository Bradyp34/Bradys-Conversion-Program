using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class VwEssilorInterfaceLog
{
    public long VwInterfaceMsgId { get; set; }

    public long LabOrderId { get; set; }

    public string? InterfaceRequestMsg { get; set; }

    public DateTime? InterfaceSentTime { get; set; }

    public string? InterfaceResponseMsg { get; set; }

    public DateTime? InterfaceReceivedTime { get; set; }

    public int? SentBy { get; set; }

    public bool? IsActive { get; set; }

    public string? RequestFileName { get; set; }

    public string? ResponseFileName { get; set; }
}

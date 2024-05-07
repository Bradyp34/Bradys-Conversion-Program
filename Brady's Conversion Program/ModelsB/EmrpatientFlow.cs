using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientFlow
{
    public int PatientFlowId { get; set; }

    public int? PtId { get; set; }

    public int? ApptId { get; set; }

    public int? SiteId { get; set; }

    public int? ProviderEmpId { get; set; }

    public string? ClientSoftwarePtId { get; set; }

    public string? ClientSoftwareApptId { get; set; }

    public DateTime? FlowDate { get; set; }

    public int? FlowStatusId { get; set; }

    public DateTime? FlowStatusTimeStamp { get; set; }

    public int? FlowStatusEmpId { get; set; }

    public string? Location { get; set; }

    public string? Notes { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public DateTime? ApptTime { get; set; }

    public string? InsertGuid { get; set; }

    public string? Hl7pid18 { get; set; }

    public int? RoomId { get; set; }

    public short? FlowStatusTimeZone { get; set; }

    public short? ApptTimeZone { get; set; }
}

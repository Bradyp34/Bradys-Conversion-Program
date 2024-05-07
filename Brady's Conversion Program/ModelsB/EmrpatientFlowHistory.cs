using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientFlowHistory
{
    public int TableId { get; set; }

    public int? PatientFlowId { get; set; }

    public int? PtId { get; set; }

    public int? FlowStatusId { get; set; }

    public DateTime? FlowStatusTimeStamp { get; set; }

    public int? FlowStatusEmpId { get; set; }

    public string? Location { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientFlowStatusType
{
    public int TableId { get; set; }

    public int? PatientFlowStatusTypeId { get; set; }

    public string? Name { get; set; }

    public short ChangeRoom { get; set; }

    public int? EmrroomType { get; set; }

    public short CloseVisit { get; set; }

    public long? ListColor { get; set; }

    public short UsePreviousStatusLocation { get; set; }
}

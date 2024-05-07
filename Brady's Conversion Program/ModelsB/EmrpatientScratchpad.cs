using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrpatientScratchpad
{
    public int ScratchNoteId { get; set; }

    public int PtId { get; set; }

    public int EmpId { get; set; }

    public string ScratchNote { get; set; } = null!;

    public DateTime ScratchNoteTime { get; set; }

    public bool Standout { get; set; }

    public string? InsertGuid { get; set; }
}

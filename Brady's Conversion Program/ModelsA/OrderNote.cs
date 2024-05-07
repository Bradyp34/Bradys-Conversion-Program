using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class OrderNote
{
    public long NoteId { get; set; }

    public long OrderId { get; set; }

    public string Note { get; set; } = null!;

    public long StaffId { get; set; }

    public DateTime NoteDateTime { get; set; }

    public bool? IncludeNoteInReports { get; set; }
}

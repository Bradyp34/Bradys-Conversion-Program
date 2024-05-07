using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiStatementFile
{
    public long EdiStmtFileId { get; set; }

    public string? EdiStmtFileName { get; set; }

    public string? EdiStmtFileContent { get; set; }

    public DateTime? EdiStmtFileSentDate { get; set; }

    public int? EdiStmtFileSentBy { get; set; }

    public bool? IsActive { get; set; }

    public int? EdiStmtFileStatus { get; set; }

    public string? EdiStmtFileNotes { get; set; }
}

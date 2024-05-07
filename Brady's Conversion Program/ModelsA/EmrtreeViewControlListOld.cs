using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EmrtreeViewControlListOld
{
    public int TableId { get; set; }

    public int? ControlId { get; set; }

    public int? VisitTypeId { get; set; }

    public string? Text { get; set; }

    public string? SubText { get; set; }

    public int? ParentId { get; set; }

    public int? Itlevel { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public int? Order { get; set; }

    public int? PrioritizeOrder { get; set; }

    public int? IncludeInLetterFilter { get; set; }

    public int? ExpandOnLoad { get; set; }

    public string? DiscussionText { get; set; }

    public int? ProcType { get; set; }

    public int? ProcLocationType { get; set; }

    public int? ProcExamType { get; set; }

    public int? ProcExamLevel { get; set; }

    public short ProcDiagTestComponents { get; set; }

    public byte[] UpsizeTs { get; set; } = null!;

    public short? OrderType { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public int? BillMultiProcId { get; set; }

    public string? InsertGuid { get; set; }

    public int? Units { get; set; }

    public int? OrderModalityId { get; set; }

    public int? ModalityId { get; set; }

    public int? CodeId { get; set; }

    public int? ServiceType { get; set; }
}

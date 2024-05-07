using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrcomboControlList
{
    public int TableId { get; set; }

    public int? ControlId { get; set; }

    public string? Text { get; set; }

    /// <summary>
    /// Field that determines order
    /// </summary>
    public int? Order { get; set; }

    /// <summary>
    /// TableID of Procedure Code
    /// </summary>
    public int? CodeId { get; set; }

    /// <summary>
    /// Number to Identify Shared Combos
    /// </summary>
    public int? CameFrom { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public int? VisitTypeId { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public string? CodeIcd10 { get; set; }

    public string? CodeSnomed { get; set; }

    public int? BillMultiProcId { get; set; }

    public int? ProcLocationType { get; set; }

    public string? CodeLoinc { get; set; }

    public string? InsertGuid { get; set; }

    public int? Units { get; set; }

    public int? ModalityId { get; set; }
}

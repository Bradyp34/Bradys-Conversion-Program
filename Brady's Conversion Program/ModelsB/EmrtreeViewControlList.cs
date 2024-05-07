using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrtreeViewControlList
{
    public int TableId { get; set; }

    public int? ControlId { get; set; }

    public int? VisitTypeId { get; set; }

    public string? Text { get; set; }

    public string? SubText { get; set; }

    /// <summary>
    /// ControlID of Parent Record
    /// </summary>
    public int? ParentId { get; set; }

    /// <summary>
    /// Tree Level
    /// </summary>
    public int? Itlevel { get; set; }

    public string? Code { get; set; }

    public string? Modifier { get; set; }

    public int? Order { get; set; }

    /// <summary>
    /// -1 = yes
    /// </summary>
    public int? PrioritizeOrder { get; set; }

    /// <summary>
    /// -1 = yes
    /// </summary>
    public int? IncludeInLetterFilter { get; set; }

    /// <summary>
    /// -1 = yes
    /// </summary>
    public int? ExpandOnLoad { get; set; }

    public string? DiscussionText { get; set; }

    /// <summary>
    /// 1 = Visit, 2 = Diag Test, 3 = Refraction, 4 =Tonometry, 5 = Contact Lens Fitting, 6 = SLE Drawing, 7 = DFE Drawing, 8 = Pachymetry, 9 = Gonioscopy, 10 = Muscle Balance, 11 = Other
    /// </summary>
    public int? ProcType { get; set; }

    /// <summary>
    /// 1 = Not Location Specific, 2 = Unilateral - Add Location Modifiers,  4=Bilateral - Do not add Location Modifiers, 5 = Bilateral - Add Location and 52 if not both eyes.
    /// </summary>
    public int? ProcLocationType { get; set; }

    /// <summary>
    /// 1 = New PT, 2 = Consult, 3 = Est Pt
    /// </summary>
    public int? ProcExamType { get; set; }

    /// <summary>
    /// 1 = EM L1, 2 = EM L2, 3 = EM L3, 4= EM L4, 5 = EM L5, 6 = OE Intermediate, 7 = OE Comprehensive
    /// </summary>
    public int? ProcExamLevel { get; set; }

    /// <summary>
    /// True = Can Split Technical &amp; Professional Components
    /// </summary>
    public short ProcDiagTestComponents { get; set; }

    public byte[]? UpsizeTs { get; set; }

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

    public int? Layout { get; set; }

    public int? Design { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrimagingRequestedProcedure
{
    public int RequestedProcedureId { get; set; }

    public int? ModalityId { get; set; }

    public int? Template { get; set; }

    public int? PtId { get; set; }

    public int? ProviderEmpId { get; set; }

    public int? LocationId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? TestName { get; set; }

    public string? TestDescription { get; set; }

    public short? Mdreviewed { get; set; }

    public DateTime? MdreviewedDate { get; set; }

    public int? MdreviewedEmpId { get; set; }

    public int? CodeId { get; set; }

    public string? CodeLoinc { get; set; }

    public string? Comments { get; set; }

    public string? StudyInstanceUid { get; set; }

    public string? DicomptId { get; set; }

    public string? DicomstudyId { get; set; }

    public string? Dicommodality { get; set; }

    public string? DicomrequestedProcedureId { get; set; }

    public string? DicomscheduledProcedureStepId { get; set; }

    public string? IolselectedIolOd { get; set; }

    public string? IolselectedIolpowerOd { get; set; }

    public string? IolselectedIolexpRefOd { get; set; }

    public string? IolselectedIolOs { get; set; }

    public string? IolselectedIolpowerOs { get; set; }

    public string? IolselectedIolexpRefOs { get; set; }

    public short? CodingChargesSent { get; set; }

    public short? RpisDirty { get; set; }

    public string? RpdirtyInfo { get; set; }

    public string? InsertGuid { get; set; }

    public short? ExcludeReview { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastModified { get; set; }

    public int? CreatedEmpId { get; set; }

    public int? LastModifiedEmpId { get; set; }
}

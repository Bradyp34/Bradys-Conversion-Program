using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrimagesLinked
{
    public int LinkedImageId { get; set; }

    public string? ImageDescription { get; set; }

    public int? ImageDevice { get; set; }

    public string? ImagePath { get; set; }

    /// <summary>
    /// 1 = EMR Visit Image, 2 = Patient Documents
    /// </summary>
    public int? ImageType { get; set; }

    /// <summary>
    /// 1 = Office Document, 2 = Medical Document, 3 = Records
    /// </summary>
    public int? DocumentClass { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public int? ControlId { get; set; }

    public short Mdreview { get; set; }

    public short Mdreviewed { get; set; }

    public DateTime? MdreviewedDate { get; set; }

    public int? MdreviewedEmpId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? DocumentSha1hashes { get; set; }

    public string? InsertGuid { get; set; }

    public int? RequestedProcedureId { get; set; }

    public string? StudyInstanceUid { get; set; }

    public string? SopclassUid { get; set; }

    public string? SopinstanceUid { get; set; }

    public string? ReferencedSopinstanceUid { get; set; }

    public string? SeriesInstanceUid { get; set; }

    public int? SeriesNumber { get; set; }

    public int? InstanceNumber { get; set; }

    public int? RepresentativeFrame { get; set; }

    public string? Laterality { get; set; }

    public string? DicomptName { get; set; }

    public string? DicomptDob { get; set; }

    public string? DicomstudyId { get; set; }

    public string? DicomrequestedProcedureId { get; set; }

    public string? DicomscheduledProcedureStepId { get; set; }

    public string? Dicommodality { get; set; }

    public string? AaohandoutsInfo { get; set; }

    public int? AmendRequest { get; set; }

    public string? AmendSource { get; set; }

    public DateTime? AmendRequestDate { get; set; }

    public DateTime? AmendResultDate { get; set; }

    public short? Prioritize { get; set; }

    public string? Reference { get; set; }

    public int? RelatedIomid { get; set; }

    public int? ReconciledCcdavisitId { get; set; }

    public int? RelatedSiteId { get; set; }

    public bool? IsSummaryRecord { get; set; }

    public string? EdgeHash { get; set; }

    public short? EdgeUploadPending { get; set; }

    public int? RelatedProviderId { get; set; }

    public string? FhirCategory { get; set; }

    public string? FhirCode { get; set; }
}

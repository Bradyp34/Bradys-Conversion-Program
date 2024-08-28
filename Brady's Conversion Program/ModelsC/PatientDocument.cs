using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class PatientDocument
{
    public int Id { get; set; }

    public int PatientId { get; set; }

    public int? VisitId { get; set; }

    public string? DocumentImageType { get; set; }

    public string? DocumentDescription { get; set; }

    public string? DocumentNotes { get; set; }

    public string? FilePathName { get; set; }

    public string? PatientInsuranceCompany { get; set; }

    public string? Date { get; set; }

    public string? ImageDevice { get; set; }

    public string? DocumentClass { get; set; }

    public string? ControlId { get; set; }

    public string? Mdreview { get; set; }

    public string? Mdreviewed { get; set; }

    public string? MdreviewedDate { get; set; }

    public string? MdreviewedEmpId { get; set; }

    public string? DocumentSha1hashes { get; set; }

    public string? InsertGuid { get; set; }

    public string? RequestedProcedureId { get; set; }

    public string? StudyInstanceUid { get; set; }

    public string? SopclassUid { get; set; }

    public string? SopinstanceUid { get; set; }

    public string? ReferencedSopinstanceUid { get; set; }

    public string? SeriesInstanceUid { get; set; }

    public string? SeriesNumber { get; set; }

    public string? InstanceNumber { get; set; }

    public string? RepresentativeFrame { get; set; }

    public string? Laterality { get; set; }

    public string? DicomptName { get; set; }

    public string? DicomptDob { get; set; }

    public string? DicomstudyId { get; set; }

    public string? DicomrequestedProcedureId { get; set; }

    public string? DicomscheduledProcedureStepId { get; set; }

    public string? Dicommodality { get; set; }

    public string? AaohandoutsInfo { get; set; }

    public string? AmendRequest { get; set; }

    public string? AmendSource { get; set; }

    public string? AmendRequestDate { get; set; }

    public string? AmendResultDate { get; set; }

    public string? Prioritize { get; set; }

    public string? Reference { get; set; }

    public string? RelatedIomid { get; set; }

    public string? ReconciledCcdavisitId { get; set; }

    public string? RelatedSiteId { get; set; }

    public string? IsSummaryRecord { get; set; }

    public string? EdgeHash { get; set; }

    public string? EdgeUploadPending { get; set; }

    public string? RelatedProviderId { get; set; }

    public string? FhirCategory { get; set; }

    public string? FhirCode { get; set; }

    public string? Active { get; set; }
}

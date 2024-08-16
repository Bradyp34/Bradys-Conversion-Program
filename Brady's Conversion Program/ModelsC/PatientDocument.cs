using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class PatientDocument
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PatientID")]
    public int PatientId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DocumentImageType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DocumentDescription { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DocumentNotes { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? FilePathName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? PatientInsuranceCompany { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Date { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ImageDevice { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? DocumentClass { get; set; }

    [Column("ControlID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ControlId { get; set; }

    [Column("MDReview")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Mdreview { get; set; }

    [Column("MDReviewed")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Mdreviewed { get; set; }

    [Column("MDReviewedDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? MdreviewedDate { get; set; }

    [Column("MDReviewedEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MdreviewedEmpId { get; set; }

    [Column("DocumentSHA1Hashes")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DocumentSha1hashes { get; set; }

    [Column("InsertGUID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? InsertGuid { get; set; }

    [Column("RequestedProcedureID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? RequestedProcedureId { get; set; }

    [Column("StudyInstanceUID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? StudyInstanceUid { get; set; }

    [Column("SOPClassUID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SopclassUid { get; set; }

    [Column("SOPInstanceUID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SopinstanceUid { get; set; }

    [Column("ReferencedSOPInstanceUID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ReferencedSopinstanceUid { get; set; }

    [Column("SeriesInstanceUID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? SeriesInstanceUid { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? SeriesNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InstanceNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RepresentativeFrame { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Laterality { get; set; }

    [Column("DICOMPtName")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DicomptName { get; set; }

    [Column("DICOMPtDOB")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DicomptDob { get; set; }

    [Column("DICOMStudyID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DicomstudyId { get; set; }

    [Column("DICOMRequestedProcedureID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DicomrequestedProcedureId { get; set; }

    [Column("DICOMScheduledProcedureStepID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DicomscheduledProcedureStepId { get; set; }

    [Column("DICOMModality")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Dicommodality { get; set; }

    [Column("AAOHandoutsInfo")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AaohandoutsInfo { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AmendRequest { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AmendSource { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AmendRequestDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? AmendResultDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Prioritize { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Reference { get; set; }

    [Column("RelatedIOMID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RelatedIomid { get; set; }

    [Column("ReconciledCCDAVisitID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ReconciledCcdavisitId { get; set; }

    [Column("RelatedSiteID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RelatedSiteId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? IsSummaryRecord { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EdgeHash { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? EdgeUploadPending { get; set; }

    [Column("RelatedProviderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RelatedProviderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FhirCategory { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FhirCode { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

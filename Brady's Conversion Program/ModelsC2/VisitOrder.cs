using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

public partial class VisitOrder
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderDescription { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? OrderWhen { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? OrderScheduledDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DoNotPrintRx { get; set; }

    [Column("AddedbyFastPlanID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? AddedbyFastPlanId { get; set; }

    [Column("OrderTypeID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OrderTypeId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? OrderHasSpecimen { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? OrderSpecimenType { get; set; }

    [Column("OrderSpecimenID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OrderSpecimenId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? OrderLabResultFulfilledDate { get; set; }

    [Column("OrderLabResultID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OrderLabResultId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? OrderNeedsFollowup { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? OrderWasFollowedup { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderNotes { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SummarySent { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? OrderRemarks { get; set; }

    [Column("StudyInstanceUID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? StudyInstanceUid { get; set; }

    [Column("DICOMRequestedProcedureID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DicomrequestedProcedureId { get; set; }

    [Column("DICOMScheduledProcedureStepID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? DicomscheduledProcedureStepId { get; set; }

    [Column("OrderModalityID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? OrderModalityId { get; set; }

    [Column("ScheduledAE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ScheduledAe { get; set; }

    [Column("CodeCPT")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CodeCpt { get; set; }

    [Column("CodeSNOMED")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CodeSnomed { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? RecordedEmpRole { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SummaryTransmitted { get; set; }

    [Column("CodeLOINC")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CodeLoinc { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RefProviderFirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RefProviderLastName { get; set; }

    [Column("RefProviderID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RefProviderId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? RefProviderOrganizationName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

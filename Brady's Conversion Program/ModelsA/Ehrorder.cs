using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class Ehrorder
{
    public int EhrorderId { get; set; }

    public int? VisitOrderId { get; set; }

    public int? EhrPtId { get; set; }

    public string? AccountNumber { get; set; }

    public int? VisitId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? OrderDescription { get; set; }

    public string? OrderWhen { get; set; }

    public string? OrderScheduledDate { get; set; }

    public short DoNotPrintRx { get; set; }

    public int? AddedbyFastPlanId { get; set; }

    public string? OrderTypeId { get; set; }

    public short? OrderHasSpecimen { get; set; }

    public string? OrderSpecimenType { get; set; }

    public string? OrderSpecimenId { get; set; }

    public DateTime? OrderLabResultFulfilledDate { get; set; }

    public int? OrderLabResultId { get; set; }

    public short? OrderNeedsFollowup { get; set; }

    public short? OrderWasFollowedup { get; set; }

    public string? OrderNotes { get; set; }

    public short? SummarySent { get; set; }

    public string? OrderRemarks { get; set; }

    public string? InsertGuid { get; set; }

    public string? StudyInstanceUid { get; set; }

    public string? DicomrequestedProcedureId { get; set; }

    public string? DicomscheduledProcedureStepId { get; set; }

    public int? OrderModalityId { get; set; }

    public string? ScheduledAe { get; set; }

    public string? CodeCpt { get; set; }

    public string? CodeSnomed { get; set; }

    public int? RecordedEmpRole { get; set; }

    public short? SummaryTransmitted { get; set; }

    public string? CodeLoinc { get; set; }

    public string? RefProviderFirstName { get; set; }

    public string? RefProviderLastName { get; set; }

    public string? RefProviderId { get; set; }

    public string? RefProviderOrganizationName { get; set; }

    public string? ProvId { get; set; }

    public string? Provider { get; set; }

    public bool? SendDate { get; set; }

    public bool? NoAction { get; set; }

    public bool? Processed { get; set; }

    public bool? Replied { get; set; }
}

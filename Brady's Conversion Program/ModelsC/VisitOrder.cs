using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class VisitOrder
{
    public int Id { get; set; }

    public string? VisitId { get; set; }

    public string? PtId { get; set; }

    public string? Dosdate { get; set; }

    public string? OrderDescription { get; set; }

    public string? OrderWhen { get; set; }

    public string? OrderScheduledDate { get; set; }

    public string? DoNotPrintRx { get; set; }

    public string? AddedbyFastPlanId { get; set; }

    public string? OrderTypeId { get; set; }

    public string? OrderHasSpecimen { get; set; }

    public string? OrderSpecimenType { get; set; }

    public string? OrderSpecimenId { get; set; }

    public string? OrderLabResultFulfilledDate { get; set; }

    public string? OrderLabResultId { get; set; }

    public string? OrderNeedsFollowup { get; set; }

    public string? OrderWasFollowedup { get; set; }

    public string? OrderNotes { get; set; }

    public string? SummarySent { get; set; }

    public string? OrderRemarks { get; set; }

    public string? StudyInstanceUid { get; set; }

    public string? DicomrequestedProcedureId { get; set; }

    public string? DicomscheduledProcedureStepId { get; set; }

    public string? OrderModalityId { get; set; }

    public string? ScheduledAe { get; set; }

    public string? CodeCpt { get; set; }

    public string? CodeSnomed { get; set; }

    public string? RecordedEmpRole { get; set; }

    public string? SummaryTransmitted { get; set; }

    public string? CodeLoinc { get; set; }

    public string? RefProviderFirstName { get; set; }

    public string? RefProviderLastName { get; set; }

    public string? RefProviderId { get; set; }

    public string? RefProviderOrganizationName { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrfaxis
{
    public int FaxId { get; set; }

    public int SubmittedByEmpId { get; set; }

    public int SubmittedBySiteId { get; set; }

    public int SubmittedToSiteId { get; set; }

    public int? PtId { get; set; }

    public int? Pages { get; set; }

    public string? RecipientName { get; set; }

    public string ToFaxNumber { get; set; } = null!;

    public string? FaxDocumentUri { get; set; }

    public int? ImageType { get; set; }

    public string? OriginalDocument { get; set; }

    public int? LinkedImageId { get; set; }

    public DateTime? SubmittedTime { get; set; }

    public string? Subject { get; set; }

    public string? Memo { get; set; }

    public int StatusId { get; set; }

    public int ExtendedStatusId { get; set; }

    public string? SubmissionId { get; set; }

    public bool IncludeCoverLetter { get; set; }

    public int Priority { get; set; }

    public string? SenderName { get; set; }

    public string? SenderCompany { get; set; }

    public string? SenderStreetAddress { get; set; }

    public string? SenderOfficePhone { get; set; }

    public string? SenderFaxNumber { get; set; }

    public string? Tsid { get; set; }

    public string? Csid { get; set; }

    public string? InsertGuid { get; set; }

    public string? FaxServerMessage { get; set; }

    public DateTime? CreatedTime { get; set; }

    public string? FaxServerErrorInfo { get; set; }

    public DateTime? LastUpdatedTime { get; set; }

    public string? InitialSubmissionComputer { get; set; }

    public string? InitialSubmissionWindowsUser { get; set; }

    public string? SuccessfulSubmissionComputer { get; set; }

    public string? SuccessfulSubmissionWindowsUser { get; set; }

    public string? AssignedPcname { get; set; }

    public int? StateId { get; set; }

    public int? SenderInfoSiteId { get; set; }

    public int ResubmitCount { get; set; }

    public int? VisitId { get; set; }
}

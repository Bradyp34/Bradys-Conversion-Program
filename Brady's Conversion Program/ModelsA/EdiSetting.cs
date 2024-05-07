using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiSetting
{
    public int EdiSettingId { get; set; }

    public long LocationId { get; set; }

    public string? SubmitterName { get; set; }

    public string? SubmittingEntityCode { get; set; }

    public string? SubmittingEntityContactEmail { get; set; }

    public string? SubmittingEntityContactPhone { get; set; }

    public string? SubmittingEntityContactFax { get; set; }

    public string? SubmittingEntityContactName { get; set; }

    public string ReceivingEntityName { get; set; } = null!;

    public string? ReceivingEntityCode { get; set; }

    public string? EdiFtpUserName { get; set; }

    public string? EdiFtpPassword { get; set; }

    public string? EdiFtpServer { get; set; }

    public int? EdiEligibilityDefaultProvId { get; set; }

    public bool? IsActive { get; set; }

    public decimal? EdiHcfaXOffset { get; set; }

    public decimal? EdiHcfaYOffset { get; set; }

    public string? EdiHcfaPrinterName { get; set; }

    public bool? EdiStmtWatermarkDefaultS { get; set; }

    public bool? EdiSearchEnabled { get; set; }

    public string? EdiDeductTransCode { get; set; }

    public string? EdiCoinsTransCode { get; set; }

    public string? EdiCopayTransCode { get; set; }

    public bool? EdiApiTurnedOff { get; set; }

    public string? EdiRemitVspLocation { get; set; }

    public DateTime? EdiClaimStatusLastUpdatedInf { get; set; }

    public bool? EdiRemitVspActive { get; set; }
}

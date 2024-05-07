using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InfInterfaceSetting
{
    public int InterfaceSettingId { get; set; }

    public string? InfCustomerName { get; set; }

    public string? InfCustomerAcctCode { get; set; }

    public string? InfEyeMdServer { get; set; }

    public string? InfFfpmServer { get; set; }

    public string? InfEyeMdDatabase { get; set; }

    public string? InfFfpmDatabase { get; set; }

    public string? InfInterfaceVersion { get; set; }

    public string? InfConfiguratorVersion { get; set; }

    public bool? InfDmgNavToFfpm { get; set; }

    public bool? InfDmgNavToEyeMd { get; set; }

    public bool? InfDmgFfpmToNav { get; set; }

    public bool? InfDmgFfpmToEyeMd { get; set; }

    public string? InfDmgNavFtpServer { get; set; }

    public string? InfDmgNavFtpUserName { get; set; }

    public string? InfDmgNavFtpPassword { get; set; }

    public string? InfDmgNavDropoffFolder { get; set; }

    public string? InfDmgNavPickupFolder { get; set; }

    public string? InfDmgEyeMdDropoffFolder { get; set; }

    public string? InfDmgOutgoingFiles { get; set; }

    public bool? InfSchdFfpmEyeMd { get; set; }

    public string? InfSchdEyeMdDropoffFolder { get; set; }

    public bool? InfChgFfpmToNav { get; set; }

    public bool? InfChgEyeMdToFfpm { get; set; }

    public string? InfChgFfpmDropoffFolder { get; set; }

    public string? InfChgEyeMdDropoffFolder { get; set; }

    public string? InfChgNavDropoffFolder { get; set; }

    public string? InfOptEyeMdDropoffFolder { get; set; }

    public string? InfLogFileLocation { get; set; }

    public string? InfProcessingFolder { get; set; }

    public bool? InfDeleteFiles { get; set; }

    public string? InfSendingFacility { get; set; }

    public string? InfReceivingFacility { get; set; }

    public int? InfTimerInterval { get; set; }

    public string? InfStartTime { get; set; }

    public string? InfEndTime { get; set; }

    public bool? InfEmailActive { get; set; }

    public string? InfEmailSmtpServer { get; set; }

    public string? InfEmailSendTo { get; set; }

    public string? InfEmailSendFrom { get; set; }

    public bool? InfRxInterfaceActive { get; set; }

    public int? InfRxInterfaceDefaultLab { get; set; }

    public bool? InfEssilorInterfaceActive { get; set; }

    public string? InfEssilorDeviceImportFolder { get; set; }

    public string? InfEssilorDeviceExportFolder { get; set; }

    public bool? InfEssilorDeviceDeleteFiles { get; set; }

    public bool? InfContactLensRxInterface { get; set; }

    public string? InfClxClientId { get; set; }

    public bool? InfOrderEyeMdToFfpm { get; set; }

    public bool? InfOrderReplyFfpmToEyeMd { get; set; }

    public string? InfEdiFtpUserName { get; set; }

    public string? InfEdiFtpPassword { get; set; }

    public string? InfEdiFtpServer { get; set; }

    public bool? InfEdiClaimStatus { get; set; }

    public bool? InfEdiRemits { get; set; }

    public bool? InfEdiEligibility { get; set; }

    public string? InfEdiEligibilityDownloadTime { get; set; }

    public string? InfEdiEligibilityDownloadDaysPrior { get; set; }

    public string? InfEdiClaimStatusDownloadTime { get; set; }

    public string? InfEdiClaimStatusDownloadDays { get; set; }

    public bool? InfGpiFormsActive { get; set; }

    public int? InfEhrVisitType { get; set; }

    public bool? IsActive { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emroption
{
    public int OptionId { get; set; }

    /// <summary>
    /// 0 = None, 1 = Versasuite
    /// </summary>
    public int? InterfaceSoftware { get; set; }

    public string? ClientId { get; set; }

    public string? ClientOptions { get; set; }

    public int? LastRxControlNumber { get; set; }

    public int? DbVersion { get; set; }

    public string? AlertsTono { get; set; }

    public double? LastHl7controlNumber { get; set; }

    public string? Hl7pminterfaceExportDirectory { get; set; }

    public string? Hl7pminterfaceImportDirectory { get; set; }

    public short? Hl7pminterfaceEnableExport { get; set; }

    public short? Hl7pminterfaceEnableImport { get; set; }

    public short? DontEnforceModifierFormat { get; set; }

    public short? CopyInsIntoNotes { get; set; }

    public short? IncludeTestDiagChartPrint { get; set; }

    public short? DontEnforceDiagCodeFormat { get; set; }

    public short? DontEnforceProcCodeFormat { get; set; }

    public short? DontWarnMissingDiagCode { get; set; }

    public short? Use24HourTimeFormat { get; set; }

    public short? UseDayMonthYearDateFormat { get; set; }

    public short? RequireIdcreatePt { get; set; }

    public short? RequireDobcreatePt { get; set; }

    public short? RequireIdcheckinPt { get; set; }

    public short? RequireDobcheckinPt { get; set; }

    public short? ReverseNameOrder { get; set; }

    public short? DontRequireMarkReviewedAuthentication { get; set; }

    public string? FaxServerIp { get; set; }

    public short? DontWarnofUnreviewedDocuments { get; set; }

    public short? DontEnforce10DigitPhoneFormat { get; set; }

    public short? DontEnforceUsssnformat { get; set; }

    public short? DontShowHistoryMarkReviewed { get; set; }

    public short? DontShowWorkupMarkReviewed { get; set; }

    public int? Hl7pminterfaceExportType { get; set; }

    public string? Hl7pminterfaceExportTcpsocketIp { get; set; }

    public int? Hl7pminterfaceExportTcpsocketPort { get; set; }

    public short? Hl7opticalInterfaceEnableExport { get; set; }

    public int? Hl7opticalInterfaceExportType { get; set; }

    public string? Hl7opticalInterfaceExportDirectory { get; set; }

    public string? Hl7opticalInterfaceExportTcpsocketIp { get; set; }

    public int? Hl7opticalInterfaceExportTcpsocketPort { get; set; }

    public short? DfedefaultExtended { get; set; }

    public string? SleLidsNormal { get; set; }

    public string? SleLashesNormal { get; set; }

    public string? SleAdnexaNormal { get; set; }

    public string? SleConjNormal { get; set; }

    public string? SleScleraNormal { get; set; }

    public string? SleKNormal { get; set; }

    public string? SleAcNormal { get; set; }

    public string? SleIrisNormal { get; set; }

    public string? SleLensNormal { get; set; }

    public string? DfeDiscNormal { get; set; }

    public string? DfeNflNormal { get; set; }

    public string? DfeRetinaNormal { get; set; }

    public string? DfeMaculaNormal { get; set; }

    public string? DfeVesselsNormal { get; set; }

    public string? DfePeriphNormal { get; set; }

    public string? DfeVitreousNormal { get; set; }

    public short? MedsPrintbyDefault { get; set; }

    public short? Hl7pminterfaceEnableForwarder { get; set; }

    public string? RxPartnerName { get; set; }

    public string? RxPartnerLogon { get; set; }

    public string? RxPartnerPass { get; set; }

    public int? RxProductionStatus { get; set; }

    public string? RxProductionUrl { get; set; }

    public string? RxProductionWebUrl { get; set; }

    public string? RxPartnerTestName { get; set; }

    public string? RxPartnerTestLogon { get; set; }

    public string? RxPartnerTestPass { get; set; }

    public string? RxTestUrl { get; set; }

    public string? RxTestWebUrl { get; set; }

    public string? RxSoapurl { get; set; }

    public string? RxOptions { get; set; }

    public string? InactivityTimeout { get; set; }

    public string? Hl7opticalInterfaceHttpaddress { get; set; }

    public short? VisitSnapshotAfterChartSign { get; set; }

    public short? DisableLetterEngineSpellChecker { get; set; }

    public string? EyeMdemrwebPortalAddress { get; set; }

    public string? EyeMdemrwebPortalInitialPass { get; set; }

    public string? EyeMdemrchargeMsh3 { get; set; }

    public string? EyeMdemrchargeMsh4 { get; set; }

    public string? EyeMdemrchargeMsh5 { get; set; }

    public string? EyeMdemrchargeMsh6 { get; set; }

    public string? InactivityTimeoutQuit { get; set; }

    public short? SendWebPortalAfterChartSign { get; set; }

    public string? PmintAdschttpAddress { get; set; }

    public string? PmintAdscinstanceName { get; set; }

    public string? ChartPrintUseHpiletterText { get; set; }

    public short? DontRequireChartSignAuthentication { get; set; }

    public short? DontShowMedStartDateInVisitSummary { get; set; }

    public int? DilatedAlertMins { get; set; }

    public short? SupressDiagSuggestion { get; set; }

    public string? PmintAdscelitePath { get; set; }

    public string? PmintAdsceliteServer { get; set; }

    public string? DefaultSpecRxExpires { get; set; }

    public string? DefaultClexpires { get; set; }

    public short? DoNotChangeStatusAfterSendtoPm { get; set; }

    public string? QualityReportingMedicareFilter { get; set; }

    public int? TrainingMediaVersion { get; set; }

    public int? DiagTestIdtypeUsed { get; set; }

    public short? PrintLicenseNumLensRx { get; set; }

    public string? UnSentCodingExceptions { get; set; }

    public string? PmintMdsHttpAddress { get; set; }

    public string? PmintMdsDatabaseName { get; set; }

    public short? DicomserverEnable { get; set; }

    public int? LogicVersion { get; set; }

    public int? AaohandOutsVersion { get; set; }

    public string? AaohandoutsLicense { get; set; }

    public short? RemoveChartPrintCredit { get; set; }

    public int? CodingMode { get; set; }

    public string? NtptimeServer { get; set; }

    public int? AlertsTearOsmolarity { get; set; }

    public int? AlertsTearOsmolarityDiff { get; set; }

    public short? VeracityEnable { get; set; }

    public string? PmintOpenPmhttpAddress { get; set; }

    public string OutgoingFaxCopyToLocation { get; set; } = null!;

    public string InfoButtonUri { get; set; } = null!;

    public string GatewayVersion { get; set; } = null!;

    public int? FaxingProviderType { get; set; }

    public string? EtherFaxApikey { get; set; }

    public string? MsfaxDefaultCoverPageName { get; set; }

    public int? DefaultFaxGatewaySiteId { get; set; }

    public bool? MultiFactorAuthenticationEnabled { get; set; }

    public int? MultiFactorAuthenticationExpireDays { get; set; }

    public DateTime LastUpdated { get; set; }

    public short UseRxPaperForStaffOrders { get; set; }

    public string? OpticalIntegrationUserName { get; set; }

    public string? OpticalIntegrationPassword { get; set; }

    public int MaximumPasswordAgeDays { get; set; }

    public int MinimumPasswordLength { get; set; }

    public int MinimumPasswordComplexity { get; set; }

    public int ScanningInterfaceType { get; set; }

    public string? PmintMedinformatixPath { get; set; }

    public string? PmintMedinformatixCompany { get; set; }

    public int? DaysToKeepHl7logFiles { get; set; }

    public int ContactLensCatalogId { get; set; }

    public short SpectacleRxPrintShowVa { get; set; }

    public short SpectacleRxPrintShowPd { get; set; }

    public short AutoCopyFromPreviousPohpmh { get; set; }

    public short EyetelligenceEnable { get; set; }

    public int PatientEngagementOption { get; set; }

    public string? PatientEngagementInfo { get; set; }

    public short PatientIntakeEnabled { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GeneralOption
{
    public bool Icd9only { get; set; }

    public bool Icd10only { get; set; }

    public bool AddNewPatient { get; set; }

    public bool UpdatePatient { get; set; }

    public bool SendDemographicPaymentsToExternalSystem { get; set; }

    public bool SendToPmactive { get; set; }

    public int AcctNumberFormat { get; set; }

    public bool? ShowAltAccountNumber { get; set; }

    public string? AltAccountNumLabel { get; set; }

    public bool BillByProvider { get; set; }

    public int MonthEndReminderDays { get; set; }

    public int YearEndMonth { get; set; }

    public bool AllowTransactionCodesEdit { get; set; }

    public bool EomAndEoyDatabaseBackupEnabled { get; set; }

    public string BackupFilePath { get; set; } = null!;

    public bool ElectronicStatements { get; set; }

    public int NextStatementDueDays { get; set; }

    public bool EmailStatements { get; set; }

    public bool? IncludePreFfpm50Orders { get; set; }

    public bool SendChargeToExternalSystem { get; set; }

    public bool IncludeTransactionsWithChargesToExternalSystem { get; set; }

    public bool LockDownSendChargesToExternalSystemButtonAndOrderChargesAndTransactions { get; set; }

    public bool LockDownSendChargesToExternalSystemButtonOnly { get; set; }

    public bool IsCcbActive { get; set; }

    public int CcbInsuranceId { get; set; }

    public string CcbServerName { get; set; } = null!;

    public string CcbServerUserName { get; set; } = null!;

    public string CcbServerPassword { get; set; } = null!;

    public int CcbChargeEligibilityDaysAfterFinalNotice { get; set; }

    public long CcbServerPortNumber { get; set; }

    public bool CcbUpdatePatientOnholdValue { get; set; }

    public bool EhrOrders { get; set; }

    public bool UpdatePatientInScheduling { get; set; }

    public string OpenEdgeBaseUrl { get; set; } = null!;

    public bool OpenEdgeElectronicStatements { get; set; }

    public string? OpenEdgeApiKey { get; set; }

    public string? OpenEdgeApiSecret { get; set; }

    public int OpenEdgeElectronicStatementPaymentsProcessingInterval { get; set; }

    public bool IsLmsActive { get; set; }

    public bool SelectEmailOrTextStatementAutomatically { get; set; }

    public bool IsBillingCustomer { get; set; }

    public bool DisplayEhrChargesReversalQuestion { get; set; }

    public int OpenEdgeElectronicStatementAdditionallySendStatementToEdiAgingBucketValue { get; set; }

    public bool OpenEdgeCallpopActive { get; set; }

    public bool OpenEdgeFormsActive { get; set; }

    public bool OpenEdgeAutomaticallyAddCompletedFormsActive { get; set; }

    public bool OpenEdgeFormsDemographicsOndemandFormOnly { get; set; }

    public bool VmMigrated { get; set; }
}

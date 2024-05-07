using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GeneralOptionsTempEoyFix
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
}

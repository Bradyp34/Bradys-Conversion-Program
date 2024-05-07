using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class StaffPrintOption
{
    public int Id { get; set; }

    public int StaffId { get; set; }

    public bool IncludeCharges { get; set; }

    public bool IncludeOrderNotes { get; set; }

    public bool IncludePayments { get; set; }

    public bool IncludeAdjustments { get; set; }

    public bool IncludeDescriptions { get; set; }

    public bool IncludeRefunds { get; set; }

    public bool IncludeTransfers { get; set; }

    public bool IncludeFamilyCharges { get; set; }

    public bool IncludeChargesCpt { get; set; }

    public bool IncludeChargesPrimaryDiagnosisCode { get; set; }

    public bool IncludeProvider { get; set; }

    public bool IncludeEstimatedInsurance { get; set; }

    public bool IncludeEstimatedPatientBalance { get; set; }
}

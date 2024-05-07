using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class StatementParameter
{
    public decimal MinimumBalance { get; set; }

    public decimal MaximumBalance { get; set; }

    public int NextStatementDueDays { get; set; }

    public bool ShowPaidOffChargeOnce { get; set; }

    public bool ExcludeInsuranceOpenOnlyCharges { get; set; }

    public string CurrentNoPaymentMadeLine1 { get; set; } = null!;

    public string CurrentNoPaymentMadeLine2 { get; set; } = null!;

    public string CurrentNoPaymentMadeLine3 { get; set; } = null!;

    public string CurrentNoPaymentMadeLine4 { get; set; } = null!;

    public string ThirtyNoPaymentMadeLine1 { get; set; } = null!;

    public string ThirtyNoPaymentMadeLine2 { get; set; } = null!;

    public string ThirtyNoPaymentMadeLine3 { get; set; } = null!;

    public string ThirtyNoPaymentMadeLine4 { get; set; } = null!;

    public string SixtyNoPaymentMadeLine1 { get; set; } = null!;

    public string SixtyNoPaymentMadeLine2 { get; set; } = null!;

    public string SixtyNoPaymentMadeLine3 { get; set; } = null!;

    public string SixtyNoPaymentMadeLine4 { get; set; } = null!;

    public string NinetyNoPaymentMadeLine1 { get; set; } = null!;

    public string NinetyNoPaymentMadeLine2 { get; set; } = null!;

    public string NinetyNoPaymentMadeLine3 { get; set; } = null!;

    public string NinetyNoPaymentMadeLine4 { get; set; } = null!;

    public string CurrentMostRecentPaymentWithinLine1 { get; set; } = null!;

    public string CurrentMostRecentPaymentWithinLine2 { get; set; } = null!;

    public string CurrentMostRecentPaymentWithinLine3 { get; set; } = null!;

    public string CurrentMostRecentPaymentWithinLine4 { get; set; } = null!;

    public string ThirtyMostRecentPaymentWithinLine1 { get; set; } = null!;

    public string ThirtyMostRecentPaymentWithinLine2 { get; set; } = null!;

    public string ThirtyMostRecentPaymentWithinLine3 { get; set; } = null!;

    public string ThirtyMostRecentPaymentWithinLine4 { get; set; } = null!;

    public string SixtyMostRecentPaymentWithinLine1 { get; set; } = null!;

    public string SixtyMostRecentPaymentWithinLine2 { get; set; } = null!;

    public string SixtyMostRecentPaymentWithinLine3 { get; set; } = null!;

    public string SixtyMostRecentPaymentWithinLine4 { get; set; } = null!;

    public string NinetyMostRecentPaymentWithinLine1 { get; set; } = null!;

    public string NinetyMostRecentPaymentWithinLine2 { get; set; } = null!;

    public string NinetyMostRecentPaymentWithinLine3 { get; set; } = null!;

    public string NinetyMostRecentPaymentWithinLine4 { get; set; } = null!;
}

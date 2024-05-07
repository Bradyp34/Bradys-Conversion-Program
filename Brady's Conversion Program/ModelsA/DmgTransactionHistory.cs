using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgTransactionHistory
{
    public long TransactionId { get; set; }

    public long PatientId { get; set; }

    public long OrderId { get; set; }

    public long? SecondaryActorId { get; set; }

    public long StaffId { get; set; }

    public string? TransactionType { get; set; }

    public string? TransactionDetails { get; set; }

    public DateTime? TransactionDateTime { get; set; }

    public string? Notes { get; set; }
}

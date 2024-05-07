using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ChargeTransaction
{
    public long TransactionId { get; set; }

    public long OrderChargeId { get; set; }

    public int SequenceId { get; set; }

    public int TransactionTypeId { get; set; }

    public int TransactionCodeId { get; set; }

    public decimal TransactionAmount { get; set; }

    public string? ReferenceNumber { get; set; }

    public string? BatchNumber { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public bool? IsAcceleratedPaymentsActive { get; set; }

    public string Operator { get; set; } = null!;

    public bool Deleted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public string? DeletedUser { get; set; }

    public string CheckNumber { get; set; } = null!;

    public long InsuranceId { get; set; }

    public int ReasonId { get; set; }

    public decimal ReasonAmount { get; set; }

    public virtual ChargeTransactionCode TransactionCode { get; set; } = null!;

    public virtual ChargeTransactionType TransactionType { get; set; } = null!;
}

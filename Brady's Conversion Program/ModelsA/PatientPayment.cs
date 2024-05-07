using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class PatientPayment
{
    public long PatientPaymentId { get; set; }

    public string PaymentTransactionId { get; set; } = null!;

    public long PatientCardId { get; set; }

    public long PatientId { get; set; }

    public decimal PaymentAmount { get; set; }

    public decimal? ApprovedAmount { get; set; }

    public string PaymentType { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public string PaymentReceiptNo { get; set; } = null!;

    public string Operator { get; set; } = null!;

    public string? ApprovalCode { get; set; }

    public string? TransactionResult { get; set; }

    public long? LocationId { get; set; }

    public string? Description { get; set; }

    public string? Swiped { get; set; }

    public string? Avsresult { get; set; }

    public string? Cvresult { get; set; }

    public string? PurchaseTransactionId { get; set; }

    public string? SignatureUrl { get; set; }

    public int TransactionCodeId { get; set; }

    public string? BatchName { get; set; }

    public bool Deleted { get; set; }

    public string? FileSent { get; set; }

    public bool ExternalSystemPayment { get; set; }

    public string CheckNumber { get; set; } = null!;

    public bool IsUnAppliedCreditPayment { get; set; }

    public int Eobid { get; set; }

    public bool IsDonationPayment { get; set; }

    public string EntryType { get; set; } = null!;

    public long RegularPatientPaymentId { get; set; }

    public int ProcessingAccountId { get; set; }

    public string TerminalId { get; set; } = null!;

    public string EntryLegend { get; set; } = null!;

    public string EntryMethod { get; set; } = null!;

    public string Ac { get; set; } = null!;

    public string Atc { get; set; } = null!;

    public string Aid { get; set; } = null!;

    public string Aidname { get; set; } = null!;

    public string Tvr { get; set; } = null!;

    public string Tsi { get; set; } = null!;

    public string RespCd { get; set; } = null!;

    public string TransactionReferenceNumber { get; set; } = null!;

    public bool XchargeTransaction { get; set; }

    public bool StatementPayment { get; set; }

    public long StatementPaymentId { get; set; }

    public virtual ICollection<PatientPaymentToOrderCharge> PatientPaymentToOrderCharges { get; set; } = new List<PatientPaymentToOrderCharge>();
}

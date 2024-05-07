using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabOrder
{
    public long LabOrderId { get; set; }

    public int StatusId { get; set; }

    public int OrderTypeId { get; set; }

    public long LabId { get; set; }

    public int PackageId { get; set; }

    public int EdgeId { get; set; }

    public long ProviderId { get; set; }

    public long OrderedById { get; set; }

    public long DiagnosisCodeId { get; set; }

    public long PatientId { get; set; }

    public long OdRxId { get; set; }

    public long OsRxId { get; set; }

    public long OdLensId { get; set; }

    public long OsLensId { get; set; }

    public bool? OdLensInventory { get; set; }

    public bool? OsLensInventory { get; set; }

    public long FrameOrderInfoId { get; set; }

    public DateTime DateEntered { get; set; }

    public DateTime? DateLastUpdated { get; set; }

    public bool CustomerBilled { get; set; }

    public DateTime? DeleteQuoteDate { get; set; }

    public long LensOdCptId { get; set; }

    public long? LensOsCptId { get; set; }

    public DateTime? ServiceDate { get; set; }

    public long? InsuranceId { get; set; }

    public bool? IsRxOrder { get; set; }

    public bool? IsLabSaved { get; set; }

    public long? LocationId { get; set; }

    public string? Remarks { get; set; }

    public bool? IsFrameDispensed { get; set; }

    public DateTime? FrameDispensedDateTime { get; set; }

    public bool? IsFrameReturned { get; set; }

    public DateTime? FrameReturnedDateTime { get; set; }

    public bool? Active { get; set; }

    public string? BatchName { get; set; }

    public bool IsClxorder { get; set; }

    public long OdcontactLensId { get; set; }

    public long OscontactLensId { get; set; }

    public DateOnly? ClRxDate { get; set; }

    public string? ClExpiration { get; set; }

    public string? ClNotes { get; set; }

    public int? ClShippingCptId { get; set; }

    public bool? ClShipToPatient { get; set; }

    public bool? ClShipToClinic { get; set; }

    public bool? ClIsExternalSystemOrder { get; set; }

    public string? ClExternalSystemName { get; set; }

    public bool? OrderSentToClx { get; set; }

    public bool PreFfpm50 { get; set; }

    public bool ChargesSentToExternalSystem { get; set; }

    public DateTime? OrderStatusChangedDateTime { get; set; }

    public DateTime? ProductReceivedDateTime { get; set; }

    public DateTime? ProductNotifiedDateTime { get; set; }

    public DateTime? ProductPickedUpDateTime { get; set; }

    public string ProductReceivedOperator { get; set; } = null!;

    public string ProductNotifiedOperator { get; set; } = null!;

    public string ProductPickedUpOperator { get; set; } = null!;

    public DateTime? ProductCancelledDateTime { get; set; }

    public string? ProductCancelledOperator { get; set; }

    public string? RxExpiration { get; set; }

    public string ClWearingInstructions { get; set; } = null!;

    public DateOnly? RxDate { get; set; }

    public bool ProductNotifiedBy4Pc { get; set; }

    public bool ProductNotifiedByEcp { get; set; }

    public int OrderStaffId { get; set; }

    public int OrderPackageId { get; set; }

    public string PrismNotes { get; set; } = null!;

    public bool PreFfpm70 { get; set; }

    public string TrayNumber { get; set; } = null!;

    public int AddOnChargeId1 { get; set; }

    public int AddOnChargeId2 { get; set; }

    public int AddOnChargeId3 { get; set; }

    public int AddOnChargeId4 { get; set; }

    public int AddOnChargeId5 { get; set; }

    public int AddOnChargeId6 { get; set; }

    public int AddOnChargeId7 { get; set; }

    public int AddOnChargeId8 { get; set; }

    public string ProductNotifiedWriteBackId { get; set; } = null!;

    public bool SecondPair { get; set; }

    public bool Remake { get; set; }
}

using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class LabOrderBackupVineel
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

    public bool OdLensInventory { get; set; }

    public bool OsLensInventory { get; set; }

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
}

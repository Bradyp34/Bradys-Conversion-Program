using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class GpnOrderChargesView
{
    public long OrderChargeId { get; set; }

    public long OrderId { get; set; }

    public string? OrderChargeCategory { get; set; }

    public string OrderChargeDescription { get; set; } = null!;

    public string OrderChargeCptId { get; set; } = null!;

    public string? OrderChargeUnitCost { get; set; }

    public int OrderChargeUnits { get; set; }

    public string? OrderChargeTotalCost { get; set; }

    public string OrderChargeInsuraceName { get; set; } = null!;

    public DateTime? OrderChargeDate { get; set; }

    public long? OrderChargeBillingLocationId { get; set; }

    public long? OrderChargeProviderId { get; set; }

    public long? ChargeRefProviderId { get; set; }

    public int OrderChargePlanId { get; set; }

    public bool? OrderChargeIsTax { get; set; }

    public decimal EstimatedPatientBalance { get; set; }

    public decimal EstimatedInsuranceBalance { get; set; }

    public bool AcceptedAssignment { get; set; }

    public int PatientInsuranceId { get; set; }

    public bool? IsChargeDeleted { get; set; }

    public bool ProcessClaimYesNo { get; set; }
}

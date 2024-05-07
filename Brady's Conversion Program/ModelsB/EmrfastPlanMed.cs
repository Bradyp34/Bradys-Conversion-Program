using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrfastPlanMed
{
    public int FastPlanMedsId { get; set; }

    public int? FastPlanId { get; set; }

    public string? FastPlanMedName { get; set; }

    public string? FastPlanMedSig { get; set; }

    public string? FastPlanMedDisp { get; set; }

    public string? FastPlanMedRefill { get; set; }

    /// <summary>
    /// 1 = Eye Medications, 2 =Systemic Medications
    /// </summary>
    public int? FastPlanMedType { get; set; }

    public short FastPlanBrandMedOnly { get; set; }

    public short FastPlanSampleGiven { get; set; }

    public string? FastPlanNotes { get; set; }

    public string? FastPlanDescription { get; set; }

    public short? FastPlanMedDispType { get; set; }

    public string? FastPlanDrugStrength { get; set; }

    public string? FastPlanDrugRoute { get; set; }

    public string? FastPlanDrugForm { get; set; }

    public string? FastPlanDrugMappingId { get; set; }

    public string? FastPlanDrugAltMappingId { get; set; }

    public string? FastPlanDrugName { get; set; }

    public string? FastPlanDrugNameId { get; set; }

    public string? FastPlanMedDispUnitType { get; set; }

    public string? FastPlanSnomed { get; set; }

    public string? FastPlanRxcui { get; set; }

    public string? FastPlanDrugFdastatus { get; set; }

    public string? FastPlanDrugDeaclass { get; set; }

    public string? FastPlanRxRemarks { get; set; }

    public string? InsertGuid { get; set; }
}

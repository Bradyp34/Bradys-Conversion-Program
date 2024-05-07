using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitRxMedication
{
    public int VisitMedicationId { get; set; }

    public int? VisitId { get; set; }

    public int? PtId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? MedName { get; set; }

    public string? MedSig { get; set; }

    public string? MedDisp { get; set; }

    public string? MedRefill { get; set; }

    /// <summary>
    /// 1 = Eye Medications, 2 =Systemic Medications
    /// </summary>
    public int? MedType { get; set; }

    public short BrandMedOnly { get; set; }

    public short DoNotPrintRx { get; set; }

    public short SampleGiven { get; set; }

    public string? Notes { get; set; }

    public string? Description { get; set; }

    public int? MedTableId { get; set; }

    public short? MedDispType { get; set; }

    public string? DrugStrength { get; set; }

    public string? DrugRoute { get; set; }

    public string? DrugForm { get; set; }

    public string? DrugMappingId { get; set; }

    public string? DrugAltMappingId { get; set; }

    public string? DrugName { get; set; }

    public string? DrugNameId { get; set; }

    public string? ErxGuid { get; set; }

    public short? ErxPendingTransmit { get; set; }

    public int? CalledInLocationId { get; set; }

    public int? CalledInProviderEmpId { get; set; }

    public string? MedDispUnitType { get; set; }

    public string? Rxcui { get; set; }

    public short? IsRefill { get; set; }

    public string? OriginalMedicationId { get; set; }

    public string? OriginalMedicationDate { get; set; }

    public short? SentViaErx { get; set; }

    public string? Snomed { get; set; }

    public string? DrugFdastatus { get; set; }

    public string? DrugDeaclass { get; set; }

    public string? RxRemarks { get; set; }

    public string? InsertGuid { get; set; }

    public int? RecordedEmpRole { get; set; }

    public short? AdministeredMed { get; set; }

    public short? FormularyChecked { get; set; }

    public short? PrintedRx { get; set; }

    public bool DoNotReconcile { get; set; }

    public DateTime? RxStartDate { get; set; }

    public DateTime? RxEndDate { get; set; }

    public int? RxDurationDays { get; set; }

    public DateTime? LastModified { get; set; }

    public int? VisitDiagCodePoolId { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedEmpId { get; set; }

    public int? LastModifiedEmpId { get; set; }

    public string? ErxStatus { get; set; }
}

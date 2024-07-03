using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class RxMedication
{
    public int Id { get; set; }

    public string? VisitId { get; set; }

    public string? PtId { get; set; }

    public string? Dosdate { get; set; }

    public string? MedName { get; set; }

    public string? MedSig { get; set; }

    public string? MedDisp { get; set; }

    public string? MedRefill { get; set; }

    public string? MedType { get; set; }

    public string? BrandMedOnly { get; set; }

    public string? DoNotPrintRx { get; set; }

    public string? SampleGiven { get; set; }

    public string? Notes { get; set; }

    public string? Description { get; set; }

    public string? MedTableId { get; set; }

    public string? MedDispType { get; set; }

    public string? DrugStrength { get; set; }

    public string? DrugRoute { get; set; }

    public string? DrugForm { get; set; }

    public string? DrugMappingId { get; set; }

    public string? DrugAltMappingId { get; set; }

    public string? DrugName { get; set; }

    public string? DrugNameId { get; set; }

    public string? ErxGuid { get; set; }

    public string? ErxPendingTransmit { get; set; }

    public string? CalledInLocationId { get; set; }

    public string? CalledInProviderEmpId { get; set; }

    public string? MedDispUnitType { get; set; }

    public string? Rxcui { get; set; }

    public string? IsRefill { get; set; }

    public string? OriginalMedicationId { get; set; }

    public string? OriginalMedicationDate { get; set; }

    public string? SentViaErx { get; set; }

    public string? Snomed { get; set; }

    public string? DrugFdastatus { get; set; }

    public string? DrugDeaclass { get; set; }

    public string? RxRemarks { get; set; }

    public string? RecordedEmpRole { get; set; }

    public string? AdministeredMed { get; set; }

    public string? FormularyChecked { get; set; }

    public string? PrintedRx { get; set; }

    public string? DoNotReconcile { get; set; }

    public string? RxStartDate { get; set; }

    public string? RxEndDate { get; set; }

    public string? RxDurationDays { get; set; }

    public string? LastModified { get; set; }

    public string? VisitDiagCodePoolId { get; set; }

    public string? Created { get; set; }

    public string? CreatedEmpId { get; set; }

    public string? LastModifiedEmpId { get; set; }

    public string? ErxStatus { get; set; }
}

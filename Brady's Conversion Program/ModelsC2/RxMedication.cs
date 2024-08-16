using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("RxMedication")]
public partial class RxMedication
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? MedName { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? MedSig { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? MedDisp { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? MedRefill { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedType { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? BrandMedOnly { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DoNotPrintRx { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? SampleGiven { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Notes { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("MedTableID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MedTableId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MedDispType { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DrugStrength { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DrugRoute { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? DrugForm { get; set; }

    [Column("DrugMappingID")]
    [StringLength(100)]
    [Unicode(false)]
    public string? DrugMappingId { get; set; }

    [Column("DrugAltMappingID")]
    [StringLength(100)]
    [Unicode(false)]
    public string? DrugAltMappingId { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? DrugName { get; set; }

    [Column("DrugNameID")]
    [StringLength(100)]
    [Unicode(false)]
    public string? DrugNameId { get; set; }

    [Column("ERxGUID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? ErxGuid { get; set; }

    [Column("ERxPendingTransmit")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ErxPendingTransmit { get; set; }

    [Column("CalledInLocationID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CalledInLocationId { get; set; }

    [Column("CalledInProviderEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? CalledInProviderEmpId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? MedDispUnitType { get; set; }

    [Column("RXCUI")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Rxcui { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsRefill { get; set; }

    [Column("OriginalMedicationID")]
    [StringLength(500)]
    [Unicode(false)]
    public string? OriginalMedicationId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? OriginalMedicationDate { get; set; }

    [Column("SentViaERx")]
    [StringLength(10)]
    [Unicode(false)]
    public string? SentViaErx { get; set; }

    [Column("SNOMED")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Snomed { get; set; }

    [Column("DrugFDAStatus")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DrugFdastatus { get; set; }

    [Column("DrugDEAClass")]
    [StringLength(50)]
    [Unicode(false)]
    public string? DrugDeaclass { get; set; }

    [StringLength(500)]
    [Unicode(false)]
    public string? RxRemarks { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? RecordedEmpRole { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? AdministeredMed { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? FormularyChecked { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? PrintedRx { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? DoNotReconcile { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? RxStartDate { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? RxEndDate { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? RxDurationDays { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? LastModified { get; set; }

    [Column("VisitDiagCodePoolID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? VisitDiagCodePoolId { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? Created { get; set; }

    [Column("CreatedEmpID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? CreatedEmpId { get; set; }

    [Column("LastModifiedEmpID")]
    [StringLength(20)]
    [Unicode(false)]
    public string? LastModifiedEmpId { get; set; }

    [Column("ERxStatus")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ErxStatus { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

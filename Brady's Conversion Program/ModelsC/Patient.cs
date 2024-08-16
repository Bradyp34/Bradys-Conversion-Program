using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class Patient
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PMPatientID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PmpatientId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? ChartNumber { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? MiddleName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [Column("PatientDOB")]
    [StringLength(20)]
    [Unicode(false)]
    public string? PatientDob { get; set; }

    [StringLength(50)]
    public string? PatientSex { get; set; }

    [Column("PatientSSN")]
    [StringLength(110)]
    public string? PatientSsn { get; set; }

    [StringLength(50)]
    public string? PatientGuardianNameFirst { get; set; }

    [StringLength(50)]
    public string? PatientGuardianNameLast { get; set; }

    [StringLength(50)]
    public string? PatientGuardianNameMiddle { get; set; }

    [Column("PatientGuardianDOB", TypeName = "datetime")]
    public DateTime? PatientGuardianDob { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PatientCreated { get; set; }

    public int? PatientEmpCreated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PatientLastEdited { get; set; }

    public int? PatientEmpLastEdited { get; set; }

    public string? PatientAlert { get; set; }

    [Column("upsizeTs")]
    public byte[]? UpsizeTs { get; set; }

    public string? PatientAddress { get; set; }

    public string? PatientAddress2 { get; set; }

    [StringLength(50)]
    public string? PatientCity { get; set; }

    [StringLength(50)]
    public string? PatientState { get; set; }

    [StringLength(50)]
    public string? PatientZip { get; set; }

    [StringLength(255)]
    public string? PatientInsPri { get; set; }

    [Column("PatientInsPriID")]
    [StringLength(50)]
    public string? PatientInsPriId { get; set; }

    [StringLength(255)]
    public string? PatientInsSec { get; set; }

    [Column("PatientInsSecID")]
    [StringLength(50)]
    public string? PatientInsSecId { get; set; }

    [StringLength(50)]
    public string? PatientHomePhone { get; set; }

    [StringLength(50)]
    public string? PatientMobilePhone { get; set; }

    [StringLength(50)]
    public string? PatientWorkPhone { get; set; }

    [Column("PMImportCheckInNote")]
    public string? PmimportCheckInNote { get; set; }

    [StringLength(50)]
    public string? PatientFaxPhone { get; set; }

    [Column("PatientDefaultRefProviderID")]
    public int? PatientDefaultRefProviderId { get; set; }

    [Column("PatientDefaultPriProviderID")]
    public int? PatientDefaultPriProviderId { get; set; }

    public string? PatientNote { get; set; }

    [Column("PatientDefaultEyeCareProviderID")]
    public int? PatientDefaultEyeCareProviderId { get; set; }

    [Column("PatientEMail")]
    [StringLength(255)]
    public string? PatientEmail { get; set; }

    [Column("ERxSystemAccessed")]
    public short? ErxSystemAccessed { get; set; }

    [StringLength(60)]
    public string? PatientPreferredLanguage { get; set; }

    [StringLength(60)]
    public string? PatientRace { get; set; }

    [StringLength(60)]
    public string? PatientEthnicity { get; set; }

    [StringLength(100)]
    public string? PatientPreferredContactMethod { get; set; }

    public short? PtDeceased { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? PtDeceasedDate { get; set; }

    public short? CopyFromDefaultPatient { get; set; }

    [Column("InsertGUID")]
    [StringLength(50)]
    public string? InsertGuid { get; set; }

    public string? PatientChartFilters { get; set; }

    [StringLength(60)]
    public string? PatientMaritalStatus { get; set; }

    public short? WebportalOptOut { get; set; }

    [Column("ClientSoftwarePtIDAssignAuth")]
    [StringLength(50)]
    public string? ClientSoftwarePtIdassignAuth { get; set; }

    [Column("ClientSoftwarePtIDAssignAuthIDType")]
    [StringLength(50)]
    public string? ClientSoftwarePtIdassignAuthIdtype { get; set; }

    [Column("GenderIdentityID")]
    public int? GenderIdentityId { get; set; }

    [StringLength(50)]
    public string? GenderIdentityOtherDescription { get; set; }

    [StringLength(50)]
    public string? GenderIdentityConceptCode { get; set; }

    [Column("SexualOrientationID")]
    public int? SexualOrientationId { get; set; }

    [StringLength(50)]
    public string? SexualOrientationOtherDescription { get; set; }

    [StringLength(50)]
    public string? SexualOrientationConceptCode { get; set; }

    [StringLength(50)]
    public string? PatientNameSuffix { get; set; }

    public string? PatientPreviousAddress { get; set; }

    public string? PatientPreviousAddress2 { get; set; }

    [StringLength(50)]
    public string? PatientPreviousCity { get; set; }

    [StringLength(50)]
    public string? PatientPreviousState { get; set; }

    [StringLength(50)]
    public string? PatientPreviousZip { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

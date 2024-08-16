using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC;

[Table("visit")]
public partial class Visit
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("OldVisitID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldVisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("ClientSoftwareApptID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ClientSoftwareApptId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VisitTech { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? VisitDoctor { get; set; }

    [Column("VisitRefProviderID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitRefProviderId { get; set; }

    [Column("VisitPriCareProviderID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitPriCareProviderId { get; set; }

    [Unicode(false)]
    public string? VisitType { get; set; }

    [Column("VisitTypeID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitTypeId { get; set; }

    [Column("VisitClassID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitClassId { get; set; }

    [Column("LinkedProcedureVisitID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? LinkedProcedureVisitId { get; set; }

    [Column("MDSignedOff")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MdsignedOff { get; set; }

    [Column("MDSignedOffDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? MdsignedOffDate { get; set; }

    [Column("MDSignedOffEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MdsignedOffEmpId { get; set; }

    [Column("VisitEyeCareProviderID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? VisitEyeCareProviderId { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ProvidedPtEducation { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ExcludeVisit { get; set; }

    [Column("CLRefNoteRemember")]
    [StringLength(500)]
    [Unicode(false)]
    public string? ClrefNoteRemember { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? ServiceType { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? InitialSignedOffRole { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? InitialSignedOff { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? InitialSignedOffDate { get; set; }

    [Column("InitialSignedOffEmpID")]
    [StringLength(10)]
    [Unicode(false)]
    public string? InitialSignedOffEmpId { get; set; }

    [Column("ReconciledCCDA")]
    [StringLength(10)]
    [Unicode(false)]
    public string? ReconciledCcda { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

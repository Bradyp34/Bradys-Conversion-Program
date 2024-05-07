using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrvisit
{
    public int VisitId { get; set; }

    public int? PtId { get; set; }

    public int? ClientSoftwarePtId { get; set; }

    public int? ClientSoftwareApptId { get; set; }

    public int? LocationId { get; set; }

    public int? ProviderEmpId { get; set; }

    /// <summary>
    /// 1=NewPT, 2=Consult, 3 = Est PT
    /// </summary>
    public int? ExamType { get; set; }

    public DateTime? Dosdate { get; set; }

    public int? VisitTech { get; set; }

    public int? VisitDoctor { get; set; }

    public int? VisitRefProviderId { get; set; }

    public int? VisitPriCareProviderId { get; set; }

    public short TabPohpmh { get; set; }

    public short TabRos { get; set; }

    public short TabCchpi { get; set; }

    public short TabWorkup { get; set; }

    public short TabWorkUp2 { get; set; }

    public short TabMbalance { get; set; }

    public short TabGonio { get; set; }

    public short TabSle { get; set; }

    public short TabDfe { get; set; }

    public short TabLensRx { get; set; }

    public short TabDiag { get; set; }

    public short TabPlan { get; set; }

    public short TabCoding { get; set; }

    public string? VisitType { get; set; }

    /// <summary>
    /// ID of Visit Type for use with Custom Treeview Fields
    /// </summary>
    public int? VisitTypeId { get; set; }

    /// <summary>
    /// 0 = Regular Office Visit, 1 = Procedure Related Visit
    /// </summary>
    public int? VisitClassId { get; set; }

    public int? LinkedProcedureVisitId { get; set; }

    /// <summary>
    /// OD, OS, OU, LT, RT, or Null
    /// </summary>
    public string? LocationSpecific { get; set; }

    public short MdsignedOff { get; set; }

    public DateTime? MdsignedOffDate { get; set; }

    public int? MdsignedOffEmpId { get; set; }

    public int? CodeId { get; set; }

    public int? ProcVisitTypeId { get; set; }

    public int? Wu2visitTypeId { get; set; }

    public short? TabVitals { get; set; }

    public int? VisitEyeCareProviderId { get; set; }

    public short? TechIsDirty { get; set; }

    public string? TechDirtyInfo { get; set; }

    public short? TechWu2isDirty { get; set; }

    public string? TechWu2dirtyInfo { get; set; }

    public short? TechRosisDirty { get; set; }

    public string? TechRosdirtyInfo { get; set; }

    public short? DiagTestIsDirty { get; set; }

    public string? DiagTestDirtyInfo { get; set; }

    public short? DoctorIsDirty { get; set; }

    public string? DoctorDirtyInfo { get; set; }

    public short? ProvidedPtEducation { get; set; }

    public short? TabImmunizations { get; set; }

    public string? InsertGuid { get; set; }

    public short? ProcIsDirty { get; set; }

    public string? ProcDirtyInfo { get; set; }

    public short? ExcludeVisit { get; set; }

    public string? ClrefNoteRemember { get; set; }

    public int? ServiceType { get; set; }

    public string? InitialSignedOffRole { get; set; }

    public short? InitialSignedOff { get; set; }

    public DateTime? InitialSignedOffDate { get; set; }

    public int? InitialSignedOffEmpId { get; set; }

    public short? TabExam { get; set; }

    public short? TabDrawing { get; set; }

    public bool ReconciledCcda { get; set; }
}

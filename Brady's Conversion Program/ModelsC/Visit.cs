using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsC;

public partial class Visit
{
    public int Id { get; set; }

    public string? PtId { get; set; }

    public string? Dosdate { get; set; }

    public string? ClientSoftwareApptId { get; set; }

    public string? VisitTech { get; set; }

    public string? VisitDoctor { get; set; }

    public string? VisitRefProviderId { get; set; }

    public string? VisitPriCareProviderId { get; set; }

    public string? VisitType { get; set; }

    public string? VisitTypeId { get; set; }

    public string? VisitClassId { get; set; }

    public string? LinkedProcedureVisitId { get; set; }

    public string? MdsignedOff { get; set; }

    public string? MdsignedOffDate { get; set; }

    public string? MdsignedOffEmpId { get; set; }

    public string? VisitEyeCareProviderId { get; set; }

    public string? ProvidedPtEducation { get; set; }

    public string? ExcludeVisit { get; set; }

    public string? ClrefNoteRemember { get; set; }

    public string? ServiceType { get; set; }

    public string? InitialSignedOffRole { get; set; }

    public string? InitialSignedOff { get; set; }

    public string? InitialSignedOffDate { get; set; }

    public string? InitialSignedOffEmpId { get; set; }

    public string? ReconciledCcda { get; set; }
}

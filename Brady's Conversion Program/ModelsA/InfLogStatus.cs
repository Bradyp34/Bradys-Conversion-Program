using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class InfLogStatus
{
    public long InterfaceLogId { get; set; }

    public string? InterfaceLog { get; set; }

    public DateTime? InterfaceLogTime { get; set; }

    public string? InterfaceLogDescription { get; set; }

    public string? InterfaceEntityName { get; set; }

    public string? InterfaceLogType { get; set; }

    public string? InterfaceLogSource { get; set; }

    public string? InterfaceLogDestination { get; set; }

    public bool? InterfaceLogResend { get; set; }

    public string? InerfaceFileType { get; set; }

    public string? InterfaceLogFileConent { get; set; }

    public string? InterfaceLogNotes { get; set; }

    public string? InterfacePatientAccount { get; set; }
}

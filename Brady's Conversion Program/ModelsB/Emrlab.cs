using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrlab
{
    public int LabId { get; set; }

    public string? LabBusinessName { get; set; }

    public string? LabName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? LabHl7facilityId { get; set; }

    public string? LabHl7exportLocation { get; set; }

    public short? LabHl7enableExport { get; set; }

    public short? LabIsActive { get; set; }
}

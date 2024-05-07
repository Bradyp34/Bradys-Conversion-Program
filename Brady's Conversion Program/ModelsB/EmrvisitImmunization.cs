using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrvisitImmunization
{
    public int VisitImmunizationId { get; set; }

    public int? PtId { get; set; }

    public int? VisitId { get; set; }

    public DateTime? Dosdate { get; set; }

    public string? SubstanceName { get; set; }

    public string? SubstanceCvxcode { get; set; }

    public DateTime? DateTimeAdministered { get; set; }

    public DateTime? DateTimeAdministeredEnd { get; set; }

    public string? AdministeredAmount { get; set; }

    public string? AdministeredUnits { get; set; }

    public string? LotNumber { get; set; }

    public string? ManufacturerName { get; set; }

    public string? ManufacturerMvxcode { get; set; }

    public string? Notes { get; set; }

    public int Status { get; set; }
}

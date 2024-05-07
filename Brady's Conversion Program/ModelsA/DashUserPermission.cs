using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DashUserPermission
{
    public int DashUserPermissingId { get; set; }

    public long StaffId { get; set; }

    public bool? PanelSpecRx { get; set; }

    public bool? PanelApptsToday { get; set; }

    public bool? PanelClRx { get; set; }

    public bool? PanelUnapplied { get; set; }

    public bool? PanelProductPickup { get; set; }

    public bool? PanelFinalize { get; set; }

    public bool? PanelProcClaims { get; set; }

    public bool? PanelClaimSatus { get; set; }

    public bool? PanelHcfaPrintQueue { get; set; }

    public bool? PanelElecRemits { get; set; }

    public bool? PanelEligDetails { get; set; }

    public bool? PanelStatements { get; set; }

    public bool? PanelCcbDetails { get; set; }

    public bool? PanelEomDetails { get; set; }

    public bool? PanelWebApptDetails { get; set; }
}

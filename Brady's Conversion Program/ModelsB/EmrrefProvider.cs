using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrrefProvider
{
    public int RefProviderId { get; set; }

    public string? RefProviderNameFull { get; set; }

    public string? RefProviderAddress { get; set; }

    public string? RefProviderCity { get; set; }

    public string? RefProviderState { get; set; }

    public string? RefProviderZip { get; set; }

    public string? RefProviderMainPhone { get; set; }

    public string? RefProviderCellPhone { get; set; }

    public string? RefProviderFax { get; set; }

    public string? RefProviderEmail { get; set; }

    public short RefProviderIsActive { get; set; }

    public string? RefProviderNpi { get; set; }

    public string? RefProviderClientSoftwareId { get; set; }

    public string? RefProviderSalutation { get; set; }

    public string? RefProviderNameLast { get; set; }

    public string? RefProviderNameFirst { get; set; }

    public string? InsertGuid { get; set; }

    public string? RefDirectMessageAddress { get; set; }

    public string? RefProviderOrganizationName { get; set; }
}

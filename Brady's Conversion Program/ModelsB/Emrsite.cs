using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrsite
{
    public int SiteId { get; set; }

    public string? SiteBusinessName { get; set; }

    public string? SiteName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    /// <summary>
    /// 1=Office, 2=Surgery Center, 3=Hospital
    /// </summary>
    public int? SiteType { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public short SiteIsActive { get; set; }

    public string? ClientSoftwareSiteId { get; set; }

    public string? SiteRxPaper { get; set; }

    public short? MainOffice { get; set; }

    public short? ShowInPtFlow { get; set; }

    public string? FaxServerOverride { get; set; }

    public string? GroupNpi { get; set; }

    public byte[]? LogoImage { get; set; }

    public int? LogoImageSize { get; set; }

    public string? Tin { get; set; }

    public string? InsertGuid { get; set; }

    public int? FaxGatewaySiteDefaultOverride { get; set; }

    public string? MainContactLastName { get; set; }

    public string? MainContactFirstName { get; set; }

    public string? EtherFaxApikeyOverride { get; set; }

    public string? EdgeServiceComputerName { get; set; }

    public string? EdgeServiceIpaddressV4 { get; set; }

    public int? EdgeServicePort { get; set; }

    public short? EdgeServiceActive { get; set; }

    public string? EdgeServiceAuthKey { get; set; }

    public string? OpticalIntegrationPracticeId { get; set; }

    public string? Address2 { get; set; }
}

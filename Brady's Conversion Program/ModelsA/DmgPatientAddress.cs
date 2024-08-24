using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientAddress {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long PatientAddressId { get; set; }

    public long PatientId { get; set; }

    public short? AddressType { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? AptSte { get; set; }

    public string? City { get; set; }

    public string? Zip { get; set; }

    public string? ZipExt { get; set; }

    public short? StateId { get; set; }

    public short? CountryId { get; set; }

    public string? HomePhone { get; set; }

    public string? WorkPhone { get; set; }

    public string? CellPhone { get; set; }

    public string? Extension { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public string? PreferredContact { get; set; }

    public bool IsActive { get; set; }

    public bool IsPrimary { get; set; }

    public bool? IsPreferred { get; set; }

    public bool? IsEmergencyContactAddress { get; set; }

    public bool? IsAlternateAddress { get; set; }

    public string? Notes { get; set; }
}

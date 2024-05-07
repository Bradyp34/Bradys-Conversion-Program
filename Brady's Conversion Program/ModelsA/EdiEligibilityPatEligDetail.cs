using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiEligibilityPatEligDetail
{
    public long EdiEligibiltyPatDetailId { get; set; }

    public long? EdiEligibilityPatientId { get; set; }

    public long? EdiEligibilityFileId { get; set; }

    public long? EdiEligibilityPatInsId { get; set; }

    public short? EdiEligibilityPatInsRank { get; set; }

    public short? EdiEligibiltyPatDetailType { get; set; }

    public string? EdiEligibilityDetailCoverageType { get; set; }

    public string? EdiEligibilityDetailStatus { get; set; }

    public string? InNetworkDeductibleIndRemaining { get; set; }

    public string? InNetworkDeductibleIndCalyear { get; set; }

    public string? OutNetworkDeductibleIndRemaining { get; set; }

    public string? OutNetworkDeductibleIndCalyear { get; set; }

    public string? NaNetworkDeductibleIndRemaining { get; set; }

    public string? NaNetworkDeductibleIndCalyear { get; set; }

    public string? InNetworkDeductibleFamRemaining { get; set; }

    public string? InNetworkDeductibleFamCalyear { get; set; }

    public string? OutNetworkDeductibleFamRemaining { get; set; }

    public string? OutNetworkDeductibleFamCalyear { get; set; }

    public string? NaNetworkDeductibleFamRemaining { get; set; }

    public string? NaNetworkDeductibleFamCalyear { get; set; }

    public string? InNetworkOtpMaxFamRemaining { get; set; }

    public string? InNetworkOtpMaxFamCalyear { get; set; }

    public string? OutNetworkOtpMaxFamRemaining { get; set; }

    public string? OutNetworkOtpMaxFamCalyear { get; set; }

    public string? NaNetworkOtpMaxFamRemaining { get; set; }

    public string? NaNetworkOtpMaxFamCalyear { get; set; }

    public string? InNetworkOtpMaxIndRemaining { get; set; }

    public string? InNetworkOtpMaxIndCalyear { get; set; }

    public string? OutNetworkOtpMaxIndRemaining { get; set; }

    public string? OutNetworkOtpMaxIndCalyear { get; set; }

    public string? NaNetworkOtpMaxIndRemaining { get; set; }

    public string? NaNetworkOtpMaxIndCalyear { get; set; }

    public string? InNetworkCopay { get; set; }

    public string? OutNetworkCopay { get; set; }

    public string? NaNetworkCopay { get; set; }

    public string? InNetworkCoinsurance { get; set; }

    public string? OutNetworkCoinsurance { get; set; }

    public string? NaNetworkCoinsurance { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? RecordUpdateDate { get; set; }
}

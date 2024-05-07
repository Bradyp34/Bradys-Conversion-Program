using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class EdiEligibilityFile
{
    public long EdiEligibityFileId { get; set; }

    public DateTime? EdiEligibiityRequestTime { get; set; }

    public long? EdiEligibilityPatientId { get; set; }

    public long? EdiEligibilityPatientInsuranceId { get; set; }

    public short? EdiEligibilityPatientInsuranceRank { get; set; }

    public string? EdiEligibilityRequestFile { get; set; }

    public long? EdiEligibilityProviderId { get; set; }

    public bool? EdiEligibilityReqSuccess { get; set; }

    public string? EdiEligibiityResponseFile { get; set; }

    public DateTime? EdiEligibilityResponseTime { get; set; }

    public bool? EdiEligibilityFileActive { get; set; }
}

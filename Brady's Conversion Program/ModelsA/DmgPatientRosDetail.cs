using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientRosDetail
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public string HaveEntIssues { get; set; } = null!;

    public string HaveSkinIssues { get; set; } = null!;

    public string HaveRespiratoryIssues { get; set; } = null!;

    public string HaveNeurologicalIssues { get; set; } = null!;

    public string HaveGenitoUrinaryIssues { get; set; } = null!;

    public string HaveCardiovascularIssues { get; set; } = null!;

    public string HaveDiabetesThyroidIssues { get; set; } = null!;

    public string HaveMusculoskeletalIssues { get; set; } = null!;

    public string HaveBloodLymphSystemIssues { get; set; } = null!;

    public string HaveGastrointestinalIssues { get; set; } = null!;

    public string HaveAllergicConditions { get; set; } = null!;

    public DateTime RecordAddedDatetime { get; set; }

    public DateTime RecordUpdatedDatetime { get; set; }
}

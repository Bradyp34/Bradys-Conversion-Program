using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientMedicalHistoryDetail
{
    public long Id { get; set; }

    public long PatientId { get; set; }

    public string PehHaveNoSignificantEyeHistory { get; set; } = null!;

    public string PehHaveLazyEye { get; set; } = null!;

    public string PehHaveGlaucoma { get; set; } = null!;

    public string PehHaveCataract { get; set; } = null!;

    public string PehHaveRetinalDetachment { get; set; } = null!;

    public string PehHaveMuscleProblems { get; set; } = null!;

    public string PehHaveInfections { get; set; } = null!;

    public string PehHaveTrauma { get; set; } = null!;

    public string PehHaveOtherPastEyeHistory { get; set; } = null!;

    public string PehOtherPastEyeHistoryDescription { get; set; } = null!;

    public string PesHaveNoSignificantEyeSurgery { get; set; } = null!;

    public string PesHaveCataracts { get; set; } = null!;

    public string PesHaveGlaucoma { get; set; } = null!;

    public string PesHaveMuscleSurgery { get; set; } = null!;

    public string PesHaveRetinalSurgery { get; set; } = null!;

    public string PesHaveRefractiveSurgery { get; set; } = null!;

    public string PesHaveEyelidSurgery { get; set; } = null!;

    public string PesHaveOtherPastEyeSurgery { get; set; } = null!;

    public string PesOtherPastEyeSurgeryDescription { get; set; } = null!;

    public string PmhHaveNoSignificantMedicalHistory { get; set; } = null!;

    public string PmhHaveDiabetes { get; set; } = null!;

    public string PmhHaveHighBloodPressure { get; set; } = null!;

    public string PmhHaveThyroid { get; set; } = null!;

    public string PmhHaveStroke { get; set; } = null!;

    public string PmhHaveCancer { get; set; } = null!;

    public string PmhHaveHeartProblems { get; set; } = null!;

    public string PmhHaveLungProblems { get; set; } = null!;

    public string PmhHaveNeurological { get; set; } = null!;

    public string PmhHaveOtherPastMedical { get; set; } = null!;

    public string PmhOtherPastMedicalDescription { get; set; } = null!;

    public string PsHaveNoSignificantSurgeries { get; set; } = null!;

    public string PsHaveHeartBloodVesselSurgery { get; set; } = null!;

    public string PsHaveCancerSurgery { get; set; } = null!;

    public string PsHaveJointOrthoSurgery { get; set; } = null!;

    public string PsHaveBrainSurgery { get; set; } = null!;

    public string PsHaveOtherPastSurgery { get; set; } = null!;

    public string PsOtherPastSurgeryDescription { get; set; } = null!;

    public DateTime RecordAddedDatetime { get; set; }

    public DateTime RecordUpdatedDatetime { get; set; }
}

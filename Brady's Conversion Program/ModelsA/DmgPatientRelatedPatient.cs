using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgPatientRelatedPatient
{
    public long PatientRelationId { get; set; }

    public long? PatientId { get; set; }

    public long? SecondaryPatientId { get; set; }

    public short? RelationId { get; set; }

    public long? AddedBy { get; set; }

    public DateTime? AddedDate { get; set; }

    public bool? IsActive { get; set; }
}

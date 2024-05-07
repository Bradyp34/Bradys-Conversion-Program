using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class WebAppointmentRequestInformation
{
    public long RequestId { get; set; }

    public long WebAppointmentKey { get; set; }

    public long PatientId { get; set; }

    public string? Title { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public DateOnly Dob { get; set; }

    public string? Ssn { get; set; }

    public string? Gender { get; set; }

    public string? HomePhone { get; set; }

    public string? CellPhone { get; set; }

    public string? WorkPhone { get; set; }

    public string? Email { get; set; }

    public int ResourceId { get; set; }

    public int BillingLocationId { get; set; }

    public int AppointmentTypeId { get; set; }

    public DateTime AppointmentDateTime { get; set; }

    public int AppointmentLength { get; set; }

    public int AppointmentStatus { get; set; }

    public DateTime AppointmentCreateDate { get; set; }

    public string? Notes { get; set; }

    public bool Active { get; set; }

    public string? InactivatedOperator { get; set; }

    public DateTime? InactivatedDateTime { get; set; }

    public DateTime RequestReceivedDateTime { get; set; }

    public DateTime RequestUpdatedDateTime { get; set; }
}

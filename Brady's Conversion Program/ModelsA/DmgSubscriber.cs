using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgSubscriber {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long SubscriberId { get; set; }

    public long PatientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public short? TitleId { get; set; }

    public short? SuffixId { get; set; }

    public short? RelationshipId { get; set; }

    public short? GenderId { get; set; }

    public short? EmploymentStatusId { get; set; }

    public long? AddressId { get; set; }

    public DateTime? Dob { get; set; }

    public string? Ssn { get; set; }

    public DateTime? AddedDate { get; set; }

    public DateTime? RemovedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public int? LastModifiedBy { get; set; }

    public bool? IsActive { get; set; }
}

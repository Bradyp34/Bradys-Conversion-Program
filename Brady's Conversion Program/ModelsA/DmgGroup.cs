using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class DmgGroup
{
    public int GroupId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? ProfessionalName { get; set; }

    public string? FederalIdNo { get; set; }

    public string? Ssn { get; set; }

    public string? Npi { get; set; }

    public long? AddressId { get; set; }

    public int PrimaryTaxonomyId { get; set; }

    public int AlternateTaxonomy1Id { get; set; }

    public int AlternateTaxonomy2Id { get; set; }

    public int AlternateTaxonomy3Id { get; set; }

    public int AlternateTaxonomy4Id { get; set; }

    public int AlternateTaxonomy5Id { get; set; }

    public int AlternateTaxonomy6Id { get; set; }

    public int AlternateTaxonomy7Id { get; set; }

    public int AlternateTaxonomy8Id { get; set; }

    public int AlternateTaxonomy9Id { get; set; }

    public int AlternateTaxonomy10Id { get; set; }

    public int AlternateTaxonomy11Id { get; set; }

    public int AlternateTaxonomy12Id { get; set; }

    public int AlternateTaxonomy13Id { get; set; }

    public int AlternateTaxonomy14Id { get; set; }

    public int AlternateTaxonomy15Id { get; set; }

    public int AlternateTaxonomy16Id { get; set; }

    public int AlternateTaxonomy17Id { get; set; }

    public int AlternateTaxonomy18Id { get; set; }

    public int AlternateTaxonomy19Id { get; set; }

    public int AlternateTaxonomy20Id { get; set; }

    public bool IsIndividual { get; set; }

    public bool IsActive { get; set; }

    public int ProcessingAccountId { get; set; }

    public string OpenEdgeExternalId { get; set; } = null!;

    public bool UseGroupCellNumberForBillingQuestions { get; set; }

    public string BillingQuestionsPhoneNumber { get; set; } = null!;

    public bool UseGroupNameAndAddressOnStatement { get; set; }

    public string StatementGroupName { get; set; } = null!;

    public int StatementAddressId { get; set; }

    public bool UseGroupNameAndAddressForRemitOnStatement { get; set; }

    public string RemitGroupName { get; set; } = null!;

    public int RemitAddressId { get; set; }

    public bool CallPopActive { get; set; }
}

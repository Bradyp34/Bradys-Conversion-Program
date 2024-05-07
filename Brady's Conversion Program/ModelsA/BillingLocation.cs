using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class BillingLocation
{
    public int BillingLocationId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Abbreviation { get; set; }

    public string? CliaIdNo { get; set; }

    public string? Npi { get; set; }

    public string? FederalIdNo { get; set; }

    public long? AddressId { get; set; }

    public int GroupId { get; set; }

    public int SalesTaxCptId { get; set; }

    public int PlaceOfTreatmentId { get; set; }

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

    public int LocationId { get; set; }

    public bool IsActive { get; set; }

    public bool TaxActive { get; set; }

    public bool IsSchedulingLocation { get; set; }

    public bool CaculateTaxOnTotalFee { get; set; }

    public bool CaculateTaxOnEstimatedPatientBalance { get; set; }

    public bool IsBillingLocation { get; set; }

    public bool IsDefaultLocation { get; set; }
}

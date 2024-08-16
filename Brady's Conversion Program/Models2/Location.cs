using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.Models2;

[Table("Location")]
public partial class Location
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("OldLocationID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? OldLocationId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? LocationName { get; set; }

    [Column("CLIA")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Clia { get; set; }

    [Column("NPI")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Npi { get; set; }

    [Column("FederalEIN")]
    [StringLength(20)]
    [Unicode(false)]
    public string? FederalEin { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string? PlaceOfTreatment { get; set; }

    [Column("PrimaryTaxonomyID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? PrimaryTaxonomyId { get; set; }

    [Column("AlternateTaxonomy1ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy1Id { get; set; }

    [Column("AlternateTaxonomy2ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy2Id { get; set; }

    [Column("AlternateTaxonomy3ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy3Id { get; set; }

    [Column("AlternateTaxonomy4ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy4Id { get; set; }

    [Column("AlternateTaxonomy5ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy5Id { get; set; }

    [Column("AlternateTaxonomy6ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy6Id { get; set; }

    [Column("AlternateTaxonomy7ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy7Id { get; set; }

    [Column("AlternateTaxonomy8ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy8Id { get; set; }

    [Column("AlternateTaxonomy9ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy9Id { get; set; }

    [Column("AlternateTaxonomy10ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy10Id { get; set; }

    [Column("AlternateTaxonomy11ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy11Id { get; set; }

    [Column("AlternateTaxonomy12ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy12Id { get; set; }

    [Column("AlternateTaxonomy13ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy13Id { get; set; }

    [Column("AlternateTaxonomy14ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy14Id { get; set; }

    [Column("AlternateTaxonomy15ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy15Id { get; set; }

    [Column("AlternateTaxonomy16ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy16Id { get; set; }

    [Column("AlternateTaxonomy17ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy17Id { get; set; }

    [Column("AlternateTaxonomy18ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy18Id { get; set; }

    [Column("AlternateTaxonomy19ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy19Id { get; set; }

    [Column("AlternateTaxonomy20ID")]
    [StringLength(50)]
    [Unicode(false)]
    public string? AlternateTaxonomy20Id { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsBilling { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? IsScheduling { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

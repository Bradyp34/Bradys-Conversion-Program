using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Brady_s_Conversion_Program.ModelsC2;

[Table("IOP")]
public partial class Iop
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("PtID")]
    public int PtId { get; set; }

    [Column("VisitID")]
    public int? VisitId { get; set; }

    [Column("DOSDate")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Dosdate { get; set; }

    [Column("IOPOD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Iopod { get; set; }

    [Column("IOPOS")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Iopos { get; set; }

    [Column("IOPDeviceUsed")]
    [StringLength(50)]
    [Unicode(false)]
    public string? IopdeviceUsed { get; set; }

    [Column("IOPTimeTaken")]
    [StringLength(20)]
    [Unicode(false)]
    public string? IoptimeTaken { get; set; }

    [Column("IOPNotes")]
    [StringLength(500)]
    [Unicode(false)]
    public string? Iopnotes { get; set; }

    [Column("IOPCC_OD")]
    [StringLength(20)]
    [Unicode(false)]
    public string? IopccOd { get; set; }

    [Column("IOPCC_OS")]
    [StringLength(20)]
    [Unicode(false)]
    public string? IopccOs { get; set; }

    [Column("CornealHysteresisOD")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CornealHysteresisOd { get; set; }

    [Column("CornealHysteresisOS")]
    [StringLength(50)]
    [Unicode(false)]
    public string? CornealHysteresisOs { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Active { get; set; }
}

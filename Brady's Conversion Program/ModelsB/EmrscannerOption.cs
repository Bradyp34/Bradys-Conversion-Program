using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class EmrscannerOption
{
    public int ScannerOptionsId { get; set; }

    public string? UsageDescription { get; set; }

    /// <summary>
    /// 1 =Try to Hide, 0 = Do not Hide
    /// </summary>
    public int? HideTwainInterface { get; set; }

    public short TryAdffirst { get; set; }

    public double? ScanTop { get; set; }

    public double? ScanLeft { get; set; }

    public double? ScanWidth { get; set; }

    public double? ScanLength { get; set; }

    /// <summary>
    /// 0 = Simplex (no duplex), 1 = Duplex
    /// </summary>
    public int? DuplexSetting { get; set; }

    /// <summary>
    /// .001 Defualt
    /// </summary>
    public double? PageRejectionCoverage { get; set; }

    public int? Dpi { get; set; }

    public short AllowMultiplePages { get; set; }

    /// <summary>
    /// 0=B&amp;W, 1=Grayscale, 2=RGB Color
    /// </summary>
    public int? ScanType { get; set; }

    /// <summary>
    /// 3=8.5x11, 4 = 8.5x14
    /// </summary>
    public int? PaperSize { get; set; }

    /// <summary>
    /// 1 = Tiff, 2 = PDF
    /// </summary>
    public int? FileType { get; set; }

    public byte[]? UpsizeTs { get; set; }

    public short? IsWiadevice { get; set; }

    public short? DoNotSetSizeorRegion { get; set; }

    public int? ModalityId { get; set; }
}

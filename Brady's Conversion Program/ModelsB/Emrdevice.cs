using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrdevice
{
    public int EmrdeviceId { get; set; }

    public string? EmrdeviceName { get; set; }

    /// <summary>
    /// Do Not Include last&quot; \&quot;
    /// </summary>
    public string? EmrdeviceFilePath { get; set; }

    /// <summary>
    /// 1 = Image Save Location, 2 = Diagnostic Device Save Location
    /// </summary>
    public int? EmrdeviceType { get; set; }

    public int? EmrdeviceTypeId { get; set; }

    public short? EmrdeviceAutoImport { get; set; }

    public int? EmrdeviceImportLogic { get; set; }

    public int? EmrdeviceLocation { get; set; }

    public int? ModalityId { get; set; }

    public short? AutoImportLimit { get; set; }

    public int? DaysToKeepImportedFiles { get; set; }

    public int? DaysToKeepNonImportedFiles { get; set; }
}

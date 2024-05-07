using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsA;

public partial class ImgImageSetting
{
    public int SettingId { get; set; }

    public string? SettingImageCategory { get; set; }

    public string? SettingImageRoot { get; set; }

    public string? SettingImageType { get; set; }

    public string? SettingImageLocation { get; set; }

    public bool? IsActive { get; set; }
}

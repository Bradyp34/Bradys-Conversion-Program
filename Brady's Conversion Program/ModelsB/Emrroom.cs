using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsB;

public partial class Emrroom
{
    public int EmrroomId { get; set; }

    public int? EmrroomType { get; set; }

    public int? EmrroomLocationId { get; set; }

    public string? EmrroomDescription { get; set; }
}

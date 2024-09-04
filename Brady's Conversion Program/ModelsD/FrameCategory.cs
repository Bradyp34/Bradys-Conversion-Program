using System;
using System.Collections.Generic;

namespace Brady_s_Conversion_Program.ModelsD;

public partial class FrameCategory
{
    public int Id { get; set; }

    public string? OldCategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    public string? SortOrder { get; set; }

    public string? Active { get; set; }

    public string? LocationId { get; set; }
}

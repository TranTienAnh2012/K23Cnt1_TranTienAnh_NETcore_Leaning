using System;
using System.Collections.Generic;

namespace ProjectImage.Models;

public partial class TtaPost
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Image { get; set; }

    public string? Content { get; set; }

    public bool Status { get; set; }
}

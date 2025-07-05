using System;
using System.Collections.Generic;

namespace ProjectImage.Models;

public partial class TtaEmployee
{
    public int TtaEmpId { get; set; }

    public string TtaEmpName { get; set; } = null!;

    public string? TtaEmpLevel { get; set; }

    public DateOnly? TtaEmpStartDate { get; set; }

    public bool? TtaEmpStatus { get; set; }
}

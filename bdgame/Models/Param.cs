using System;
using System.Collections.Generic;

namespace bdgame.Models;

public partial class Param
{
    public int ParamId { get; set; }

    public int ParamValue { get; set; }

    public DateTime? RefreshDate { get; set; }
}

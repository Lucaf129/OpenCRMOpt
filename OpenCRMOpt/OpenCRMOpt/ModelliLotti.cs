using System;
using System.Collections.Generic;

namespace OpenCRMOptModels;

public partial class ModelliLotti
{
    public int ModelloId { get; set; }

    public string Descrizione { get; set; } = null!;

    public string MacchineCompatibili { get; set; } = null!;

    public virtual ICollection<Lotti> Lottis { get; set; } = new List<Lotti>();
}

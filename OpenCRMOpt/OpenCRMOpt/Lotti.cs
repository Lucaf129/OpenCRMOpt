using System;
using System.Collections.Generic;

namespace OpenCRMOptModels;

public partial class Lotti
{
    public long LottoId { get; set; }

    public int Modello { get; set; }

    public string? Note { get; set; }

    public int Quantita { get; set; }

    public virtual ModelliLotti ModelloNavigation { get; set; } = null!;
}

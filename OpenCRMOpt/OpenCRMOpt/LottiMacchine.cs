using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRMOptModels
{
    public class LottiMacchine
    {

        public long LottoId { get; set; }


        public int Quantita { get; set; }

        public string Descrizione { get; set; } = null!;

        public string MacchineCompatibili { get; set; } = null!;
    };

}

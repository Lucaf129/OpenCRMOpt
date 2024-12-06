using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRMOptModels
{
    public class RisultatoOttimizzazione
    {

        public List<List<Lotti>> Assegnamenti { get; set; }

        public List<int> PezziAssegnati { get; set; }

        public void Initialize(int nMacchine)
        {
            for (int i = 0; i < nMacchine; i++) 
            { 
                Assegnamenti.Add(new List<Lotti>());
                PezziAssegnati.Add(0);
            }
        }

        public void AssegnaLottoAMacchina (LottiMacchine lotto, int indiceMacchina)
        {
            // get lotto from id
            Assegnamenti[indiceMacchina].Add(lotto);
            PezziAssegnati[indiceMacchina] += lotto.Quantita;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRMOptModels
{
    public class RisultatoOttimizzazione
    {


        public RisultatoOttimizzazione()
        {
            Initialize(0);
        }

        public double TempoTrascorso { get; set; }

        public int Peso
        {
            get
            {
                if (PezziAssegnati.Count > 0)
                {
                    return PezziAssegnati.Max();
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<List<long>> Assegnamenti { get; set; } = new List<List<long>>(); //Lista di lista di lotti

        public List<int> PezziAssegnati { get; set; } = new List<int>();

        public void Initialize(int nMacchine)
        {
            for (int i = 0; i < nMacchine; i++)
            {
                Assegnamenti.Add(new List<long>());
                PezziAssegnati.Add(0);
            }
        }

        public void AssegnaLottoAMacchina(LottiMacchine lotto, int indiceMacchina)
        {
            // get lotto from id
            Assegnamenti[indiceMacchina].Add(lotto.LottoId);
            PezziAssegnati[indiceMacchina] += lotto.Quantita;
        }

        public void DisassegnaLottoAMacchina(LottiMacchine lotto, int indiceMacchina)
        {
            Assegnamenti[indiceMacchina].RemoveAt(Assegnamenti[indiceMacchina].LastIndexOf(lotto.LottoId));
            PezziAssegnati[indiceMacchina] -= lotto.Quantita;
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using OpenCRMOptAPI.Controllers;
using OpenCRMOptModels;
using System.Reflection.PortableExecutable;

namespace OpenCRMOptAPI.Ottimizzazione
{
    public class Ottimizzatore
    {
        private readonly OptDbContext _context;

        public Ottimizzatore(OptDbContext context)
        {
            _context = context;
        }

        public async Task<RisultatoOttimizzazione> OttimizzaConEuristica(List<LottiMacchine> lottiMacchine)
        {

            var matriceLottiMacchine = getMatriceLottiMacchineDerivata(lottiMacchine);
            var risultato = new RisultatoOttimizzazione();

            risultato.Initialize(getNMacchine(lottiMacchine));

            var macchine = new List<List<int>>();
            // ogni int è un lotto che mando in produzione su quella macchina
            int i = 0;
            foreach (var lotto in lottiMacchine)
            {
                var minPezziAssegnati = int.MaxValue;
                var minIndiceMacchina = -1;


                foreach (var macchineAssegnabili in matriceLottiMacchine[i])
                {
                    var pezziAssegnatiAllaMacchinaCorrente = risultato.PezziAssegnati[macchineAssegnabili];

                    if (pezziAssegnatiAllaMacchinaCorrente < minPezziAssegnati)
                    {
                        minPezziAssegnati = pezziAssegnatiAllaMacchinaCorrente;
                        minIndiceMacchina = macchineAssegnabili;
                    }
                }

                risultato.AssegnaLottoAMacchina(lottiMacchine[i], minIndiceMacchina);

                i++;
            }

            return risultato;
        }

        private int getNMacchine(List<LottiMacchine> lotto)
        {
            int res = lotto.First()!.MacchineCompatibili.Count(c => c == ';') + 1;
            // conto i punti e virgola nel csv e aggiungo 1 per avere il numero di macchine

            return res;
        }

        public List<List<int>> getMatriceLottiMacchineDerivata(List<LottiMacchine> modelliLotti)
        {
            // in questa matrice ci sono le righe(lotti) e una lista di interi che stanno a significare che è producibile sulla macchina i-esima.
            var matriceLottiMacchine = getMatriceLottiMacchine(modelliLotti);
            var matriceLottiMacchineDerivata = new List<List<int>>();

            for (int j = 0; j < matriceLottiMacchine.Count; j++) // qui le macchine sono sulle colonne
            {
                matriceLottiMacchineDerivata.Add(new List<int>());
                for (int i = 0; i < matriceLottiMacchine[j].Count; i++)
                {
                    if (matriceLottiMacchine[j][i])
                    {
                        matriceLottiMacchineDerivata[j].Add(i);
                    }
                }
            }

            return matriceLottiMacchineDerivata;

        }

        public List<List<bool>> getMatriceLottiMacchine(List<LottiMacchine> lottiMacchine)
        {
            var matriceLottiMacchine = new List<List<bool>>();
            var listLottiMacchine = new List<bool>();

            foreach (var lotto in lottiMacchine)
            {
                listLottiMacchine = getListaLottiMacchine(lotto);
                matriceLottiMacchine.Add(listLottiMacchine);
            }

            return matriceLottiMacchine;

        }

        private List<bool> getListaLottiMacchine(LottiMacchine lotto)
        {
            var listLottiMacchine = new List<bool>();
            var assegnamenti = lotto.MacchineCompatibili.Split(';');

            foreach (var assegnamento in assegnamenti)
            {
                if (assegnamento == "1")
                {
                    listLottiMacchine.Add(true);
                }
                else
                {
                    listLottiMacchine.Add(false);
                }
            }

            return listLottiMacchine;

        }

        

        

        public RisultatoOttimizzazione OttimizzaNaive(List<LottiMacchine> lottiMacchineList)
        {
            List<RisultatoOttimizzazione> risultati = new List<RisultatoOttimizzazione> ();

            var matriceLottiMacchine = getMatriceLottiMacchineDerivata(lottiMacchineList);
            var nMacchine = getNMacchine(lottiMacchineList);
            int minPeso = int.MaxValue;

            RisultatoOttimizzazione bestRes = new RisultatoOttimizzazione();

            var combinazioni = matriceLottiMacchine.CartesianProduct(); // come li interpreto? lotto i esimo alla macchina assegnata

            foreach (var com in combinazioni)
            {
                RisultatoOttimizzazione res = new RisultatoOttimizzazione();
                res.Initialize(nMacchine);
                int i = 0;
                foreach(var macchinaAssegnabile in com)
                {
                    res.AssegnaLottoAMacchina(lottiMacchineList[i], macchinaAssegnabile);
                    risultati.Add(res);
                    i++;
                }

                int peso = res.Peso;

                if(peso < minPeso)
                {
                    minPeso=peso;
                    bestRes = res;
                }
            }

            return bestRes;
        }

    }
}

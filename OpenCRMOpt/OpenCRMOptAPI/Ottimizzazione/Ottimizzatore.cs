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

        public List<RisultatoOttimizzazione> OttimizzaNaive(List<LottiMacchine> lottiMacchineList)
        {
            var matriceLottiMacchine = getMatriceLottiMacchineDerivata(lottiMacchineList);

            List<RisultatoOttimizzazione> risultati = new List<RisultatoOttimizzazione>();

            var nMacchine = getNMacchine(lottiMacchineList);

            var res = new RisultatoOttimizzazione();

            res.Initialize(nMacchine);

            //risultati.AddRange(OttimizzaNaiveRicorsiva(res ,matriceLottiMacchine, lottiMacchineList, risultati, 0));




            return risultati;
        }

        private IEnumerable<RisultatoOttimizzazione> OttimizzaNaiveRicorsiva(RisultatoOttimizzazione res, List<List<int>> matriceLottiMacchine, List<LottiMacchine> lottiMacchineList, List<RisultatoOttimizzazione> risultati, int i)
        {

            var nMacchine = getNMacchine(lottiMacchineList);
            if (i== matriceLottiMacchine.Count - 1)
            {

                foreach (var macchinaAssegnabile in matriceLottiMacchine[i])
                {
                    //var r = new RisultatoOttimizzazione();

                    //r.Initialize(nMacchine);

                    res.AssegnaLottoAMacchina(lottiMacchineList[i], macchinaAssegnabile);

                    risultati.Add(res);

                    res.DisassegnaLottoAMacchina(lottiMacchineList[i], macchinaAssegnabile);

                }
                return risultati;
            }
            else
            {
                foreach (var macchinaAssegnabile in matriceLottiMacchine[i])
                {

                    res.AssegnaLottoAMacchina(lottiMacchineList[i], macchinaAssegnabile);

                    return OttimizzaNaiveRicorsiva(res, matriceLottiMacchine, lottiMacchineList, risultati, i+1);

                    //res.DisassegnaLottoAMacchina(lottiMacchineList[i], macchinaAssegnabile);
                }
                return risultati;
            }

        }

        

        public List<RisultatoOttimizzazione> OttimizzaNaive2(List<LottiMacchine> lottiMacchineList)
        {

            var matriceLottiMacchine = getMatriceLottiMacchineDerivata(lottiMacchineList);

            var res = matriceLottiMacchine.CartesianProduct();


            return null;
        }

    }
}

using OpenCRMOptModels;

namespace OpenCRMOptAPI.Ottimizzazione
{
    public class Ottimizzatore
    {

        public Ottimizzatore() { }

        public RisultatoOttimizzazione OttimizzaConEuristica(List<LottiMacchine> lottiMacchine, List<ModelliLotti> modelliLotti) 
        {
            var matriceLottiMacchine = getMatriceLottiMacchineDerivata(modelliLotti);
            var risultato = new RisultatoOttimizzazione();

            risultato.Initialize(getNMacchine(modelliLotti));

            var macchine = new List<List<int>>();
            // ogni int è un lotto che mando in produzione su quella macchina
            int i = 0;
           foreach (var lotto in matriceLottiMacchine)
            {

                // devo stabilire quanti lotti ha già da produrre quella macchina
                var assegnamento = risultato.PezziAssegnati.Min(x => matriceLottiMacchine[i].Contains(x));

                //risultato.AssegnaLottoAMacchina() // get lotto from index

                i++;
            }
            

            return null;
        }

        private int getNMacchine(List<ModelliLotti> modelliLotti)
        {
            int res = modelliLotti.First()!.MacchineCompatibili.Count(c => c == ';') + 1;
            // conto i punti e virgola nel csv e aggiungo 1 per avere il numero di macchine

            return res;
        }

        public List<List<int>> getMatriceLottiMacchineDerivata(List<ModelliLotti> modelliLotti)
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

        public List<List<bool>> getMatriceLottiMacchine(List<ModelliLotti> modelliLotti)
        {
            var matriceLottiMacchine = new List<List<bool>>();
            var listLottiMacchine = new List<bool>();

            foreach (var modelli in modelliLotti) 
            {
                listLottiMacchine = getListaLottiMacchine(modelli);
                matriceLottiMacchine.Add(listLottiMacchine);
            }

            return matriceLottiMacchine;

        }

        private List<bool> getListaLottiMacchine(ModelliLotti modelli)
        {
            var listLottiMacchine = new List<bool>();
            var assegnamenti = modelli.MacchineCompatibili.Split(';');

            foreach(var assegnamento in assegnamenti)
            {
                if(assegnamento == "1")
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
    }
}

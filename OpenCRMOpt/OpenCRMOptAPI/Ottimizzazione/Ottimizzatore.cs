using OpenCRMOptModels;

namespace OpenCRMOptAPI.Ottimizzazione
{
    public class Ottimizzatore
    {

        public Ottimizzatore() { }

        public RisultatoOttimizzazione OttimizzaConEuristica(List<LottiMacchine> lottiMacchine, List<ModelliLotti> modelliLotti) 
        {
            var matriceLottiMacchine = getMatriceLottiMacchine(modelliLotti);

            var macchine = new List<List<int>>();
            // ogni int è un lotto che mando in produzione su quella macchina

            var clearLottiMacchine = new List<List<int>>();
            // questa lista dovrà contenere gli indici di ogni macchina che può andare nel i-esimo lotto


            for(int j =0; j <= matriceLottiMacchine.Count; j++) // qui le macchine sono sulle colonne
            {
                for (int i = 0; i < matriceLottiMacchine[j].Count; i++) 
                { 
                    if (matriceLottiMacchine[j][i])
                    {
                        clearLottiMacchine[j] = new List<int>();
                        clearLottiMacchine[j].Add(i);
                    }
                }
            }

            return null;
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

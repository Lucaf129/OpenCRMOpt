using OpenCRMOptModels;

namespace OpenCRMOptAPI.Ottimizzazione
{
    public class Ottimizzatore
    {

        public Ottimizzatore() { }

        public RisultatoOttimizzazione OttimizzaConEuristica(List<LottiMacchine> lottiMacchine) 
        {




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

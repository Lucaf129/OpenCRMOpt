using OpenCRMOptModels;

namespace OpenCRMOptApp.ViewModels
{
    public class OttimizzazioneViewModel
    {

        private RisultatoOttimizzazione _risultato_con_euristica = new RisultatoOttimizzazione();
        public RisultatoOttimizzazione RisultatoConEuristica {
            get
            {
                return this._risultato_con_euristica;
            }
            set
            {
                this._risultato_con_euristica = value;
            }
        }
        

        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///


        private RisultatoOttimizzazione _risultato_naive;
        public RisultatoOttimizzazione RisultatoNaive
        {
            get
            {
                return this._risultato_naive;
            }
            set
            {
                this._risultato_naive = value;
            }
        }

        

    }
}

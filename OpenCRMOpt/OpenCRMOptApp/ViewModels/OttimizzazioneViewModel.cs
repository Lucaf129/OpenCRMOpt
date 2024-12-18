using OpenCRMOptModels;

namespace OpenCRMOptApp.ViewModels
{
    public class OttimizzazioneViewModel
    {

        public int PesoConEuristica {  get; set; }

        private RisultatoOttimizzazione _risultato_con_euristica = new RisultatoOttimizzazione();
        public RisultatoOttimizzazione RisultatoConEuristica {
            get
            {
                return this._risultato_con_euristica;
            }
            set
            {
                this.PesoConEuristica = _risultato_con_euristica.Peso;
                this._risultato_con_euristica = value;
            }
        }

        public long TempoTrascorsoConEuristica {
            get
            {
                return this._risultato_con_euristica.TempoTrascorso;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        ///

        public int PesoNaive { get; set; }

        private RisultatoOttimizzazione _risultato_naive;
        public RisultatoOttimizzazione RisultatoNaive
        {
            get
            {
                return this._risultato_naive;
            }
            set
            {
                this.PesoNaive = _risultato_naive.Peso;
                this._risultato_naive = value;
            }
        }

        public long TempoTrascorsoNaive
        {
            get
            {
                return this._risultato_naive.TempoTrascorso;
            }
        }

    }
}

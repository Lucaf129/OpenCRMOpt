using Newtonsoft.Json;
using OpenCRMOptAPI.Ottimizzazione;
using OpenCRMOptModels;
using static System.Net.Mime.MediaTypeNames;

namespace OpenCRMOptTest
{
    [TestClass]
    public class OttimizzatoreTest
    {

        [TestMethod]
        public void GetMatriceLottiMacchine()
        {
            var serializedInput = 
                "[{'modelloId':1,'descrizione':'Modello A','macchineCompatibili':'1;0;0;1;0','lottis':[]}," +
                "{'modelloId':2,'descrizione':'Modello B','macchineCompatibili':'0;0;1;0;1','lottis':[]}, "+
                "{'modelloId':3,'descrizione':'Modello C','macchineCompatibili':'0;1;0;0;0','lottis':[]},"+
                "{'modelloId':4,'descrizione':'Modello D','macchineCompatibili':'1;0;1;0;0','lottis':[]}, "+
                "{'modelloId':5,'descrizione':'Modello E','macchineCompatibili':'0;0;0;1;0','lottis':[]}, "+
                "{'modelloId':6,'descrizione':'Modello F','macchineCompatibili':'0;0;1;1;0','lottis':[]}]";
            var ottimizzatore = new Ottimizzatore();

            // deserializzo la stringa
            var modelliLottiList = JsonConvert.DeserializeObject<List<ModelliLotti>>(serializedInput);

            var expected = new List<List<bool>>() {
                new List<bool>(){true, false, false, true, false},
                new List<bool>(){false, false, true, false, true},
                new List<bool>(){false, true, false, false, false},
                new List<bool>(){true, false, true, false, false},
                new List<bool>(){false, false, false, true, false},
                new List<bool>(){false, false, true, true, false} };


            if (modelliLottiList != null)
            {
                var result = ottimizzatore.getMatriceLottiMacchine(modelliLottiList);

                int i = 0;
                foreach (var list in expected)
                {
                    CollectionAssert.AreEqual(list, result[i]);
                    i++;
                }
                
            }

        }


        [TestMethod]
        public void OttimizzazioneConEuristica()
        {

            var serializedInput = "[{'LottoId':1,'Quantita':200,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
                "{'LottoId':2,'Quantita':500,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
                "{'LottoId':3,'Quantita':350,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
                "{'LottoId':4,'Quantita':800,'Descrizione':'Modello C ','MacchineCompatibili':'0;1;0;0;0'}," +
                "{'LottoId':5,'Quantita':600,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
                "{'LottoId':6,'Quantita':700,'Descrizione':'Modello E','MacchineCompatibili':'0;0;0;1;0'}," +
                "{'LottoId':7,'Quantita':300,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
                "{'LottoId':8,'Quantita':800,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
                "{'LottoId':9,'Quantita':1200,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}]";
            var ottimizzatore = new Ottimizzatore();

            // deserializzo la stringa
            var lottiMacchineList = JsonConvert.DeserializeObject<List<LottiMacchine>>(serializedInput);


            if (lottiMacchineList != null)
            {
                RisultatoOttimizzazione result = ottimizzatore.OttimizzaConEuristica(lottiMacchineList);


            }



        }
    }
}
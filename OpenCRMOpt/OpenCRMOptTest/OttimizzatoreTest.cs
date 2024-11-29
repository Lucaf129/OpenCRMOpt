using Newtonsoft.Json;
using OpenCRMOptAPI.Ottimizzazione;

namespace OpenCRMOptTest
{
    [TestClass]
    public class OttimizzatoreTest
    {
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


            


            ottimizzatore.OttimizzaConEuristica();
        }
    }
}
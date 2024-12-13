using Moq;
using Newtonsoft.Json;
using OpenCRMOptAPI.Ottimizzazione;
using OpenCRMOptModels;
using System.Drawing.Text;
using static System.Net.Mime.MediaTypeNames;

namespace OpenCRMOptTest
{
    [TestClass]
    public class OttimizzatoreTest
    {

        private OptDbContext _context = new OptDbContext();

        [TestMethod]
        public void GetMatriceLottiMacchine()
        {



            var serializedInputLotti = "[{'LottoId':1,'Quantita':200,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
               "{'LottoId':2,'Quantita':500,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
               "{'LottoId':3,'Quantita':350,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
               "{'LottoId':4,'Quantita':800,'Descrizione':'Modello C','MacchineCompatibili':'0;1;0;0;0'}," +
               "{'LottoId':5,'Quantita':600,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
               "{'LottoId':6,'Quantita':700,'Descrizione':'Modello E','MacchineCompatibili':'0;0;0;1;0'}," +
               "{'LottoId':7,'Quantita':300,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
               "{'LottoId':8,'Quantita':800,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
               "{'LottoId':9,'Quantita':1200,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}]";


            var ottimizzatore = new Ottimizzatore(_context);

            // deserializzo la stringa
            var lottiMacchineList = JsonConvert.DeserializeObject<List<LottiMacchine>>(serializedInputLotti);

            var expected = new List<List<bool>>() {
                new List<bool>(){true, false, false, true, false},
                new List<bool>(){false, false, true, false, true},
                new List<bool>(){false, false, true, false, true},
                new List<bool>(){false, true, false, false, false},
                new List<bool>(){true, false, true, false, false},
                new List<bool>(){false, false, false, true, false},
                new List<bool>(){true, false, true, false, false},
                new List<bool>(){true, false, false, true, false},
                new List<bool>(){true, false, true, false, false} };


            if (lottiMacchineList != null)
            {
                var result = ottimizzatore.getMatriceLottiMacchine(lottiMacchineList);

                int i = 0;
                foreach (var list in expected)
                {
                    CollectionAssert.AreEqual(list, result[i]);
                    i++;
                }
            }
        }

        [TestMethod]
        public void GetMatriceLottiMacchineDerivata()
        {

            var serializedInputLotti = "[{'LottoId':1,'Quantita':200,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
               "{'LottoId':2,'Quantita':500,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
               "{'LottoId':3,'Quantita':350,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
               "{'LottoId':4,'Quantita':800,'Descrizione':'Modello C','MacchineCompatibili':'0;1;0;0;0'}," +
               "{'LottoId':5,'Quantita':600,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
               "{'LottoId':6,'Quantita':700,'Descrizione':'Modello E','MacchineCompatibili':'0;0;0;1;0'}," +
               "{'LottoId':7,'Quantita':300,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
               "{'LottoId':8,'Quantita':800,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
               "{'LottoId':9,'Quantita':1200,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}]";


            var ottimizzatore = new Ottimizzatore(_context);

            // deserializzo la stringa
            var lottiMacchineList = JsonConvert.DeserializeObject<List<LottiMacchine>>(serializedInputLotti);

            var expected = new List<List<int>>() {
                new List<int>(){0,3},
                new List<int>(){2,4},
                new List<int>(){2,4},
                new List<int>(){1},
                new List<int>(){0,2},
                new List<int>(){3},
                new List<int>(){0,2},
                new List<int>(){0,3},
                new List<int>(){0,2}};


            if (lottiMacchineList != null)
            {
                var result = ottimizzatore.getMatriceLottiMacchineDerivata(lottiMacchineList);

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

            var serializedOutput = "{\"Assegnamenti\":[[1,5,9],[4],[2,7],[6,8],[3]],\"PezziAssegnati\":[2000,800,800,1500,350]}";

            var ottimizzatore = new Ottimizzatore(_context);

            // deserializzo la stringa
            var lottiMacchineList = JsonConvert.DeserializeObject<List<LottiMacchine>>(serializedInput);

            if (lottiMacchineList != null)
            {
                RisultatoOttimizzazione result = ottimizzatore.OttimizzaConEuristica(lottiMacchineList).GetAwaiter().GetResult();

                var actualResult = JsonConvert.SerializeObject(result);

                Assert.AreEqual(serializedOutput, actualResult);
            }



        }

        [TestMethod]
        public void OttimizzazioneNaive()
        {

            var serializedInput = "[{'LottoId':1,'Quantita':200,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
                "{'LottoId':2,'Quantita':500,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}]";
                //"{'LottoId':3,'Quantita':350,'Descrizione':'Modello B','MacchineCompatibili':'0;0;1;0;1'}," +
                //"{'LottoId':4,'Quantita':800,'Descrizione':'Modello C ','MacchineCompatibili':'0;1;0;0;0'}," +
                //"{'LottoId':5,'Quantita':600,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
                //"{'LottoId':6,'Quantita':700,'Descrizione':'Modello E','MacchineCompatibili':'0;0;0;1;0'}," +
                //"{'LottoId':7,'Quantita':300,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}," +
                //"{'LottoId':8,'Quantita':800,'Descrizione':'Modello A','MacchineCompatibili':'1;0;0;1;0'}," +
                //"{'LottoId':9,'Quantita':1200,'Descrizione':'Modello D','MacchineCompatibili':'1;0;1;0;0'}]";

            //var serializedOutput = "{\"Assegnamenti\":[[1,5,9],[4],[2,7],[6,8],[3]],\"PezziAssegnati\":[2000,800,800,1500,350]}";

            var ottimizzatore = new Ottimizzatore(_context);

            // deserializzo la stringa
            var lottiMacchineList = JsonConvert.DeserializeObject<List<LottiMacchine>>(serializedInput);

            if (lottiMacchineList != null)
            {
                List<RisultatoOttimizzazione> results = ottimizzatore.OttimizzaNaive2(lottiMacchineList);

               // var actualResult = JsonConvert.SerializeObject(result);

                //Assert.AreEqual(serializedOutput, actualResult);
            }



        }
    }
}
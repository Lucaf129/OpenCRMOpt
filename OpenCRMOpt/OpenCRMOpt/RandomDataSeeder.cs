using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRMOptModels
{
    public class RandomDataSeeder
    {

        [Range(1,100)]
        public int NLotti {  get; set; }

        [Range(1, 100)]
        public int NMacchine { get; set; }

        [Range(1, 100)]
        public int NModelli { get; set; }

        public float CoefSparsitaMatrice { get; set; }

    }
}

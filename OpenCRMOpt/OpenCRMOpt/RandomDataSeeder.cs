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
        public int nLotti {  get; set; }

        [Range(1, 100)]
        public int nMacchine { get; set; }

        [Range(1, 100)]
        public int nModelli { get; set; }

        public float coefSparsitaMatrice { get; set; }

    }
}

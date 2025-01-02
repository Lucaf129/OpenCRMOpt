using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCRMOptModels.Extensions
{
    public static class RandomExtension
    {
        private static readonly Random _random = new Random();

        public static float NextNormalFloat(this Random random, float mean)
        {
            float stdDev = mean * 0.4f; // 40% of the mean
            // Box-Muller transform   https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform
            double u1 = 1.0 - random.NextDouble(); // uniform(0,1] random doubles
            double u2 = 1.0 - random.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); // random normal(0,1)
            double randNormal = mean + stdDev * randStdNormal; // random normal(mean,stdDev)
            return (float)randNormal;
        }
    }
}

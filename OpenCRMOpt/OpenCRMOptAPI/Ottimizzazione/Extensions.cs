namespace OpenCRMOptAPI.Ottimizzazione
{
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            IEnumerable<IEnumerable<T>> result = emptyProduct;
            foreach (IEnumerable<T> sequence in sequences)
            {
                result = from accseq in result from item in sequence select accseq.Concat(new[] { item });
            }
            return result;
        }
    }
}

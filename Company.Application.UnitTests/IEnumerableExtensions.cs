namespace Company.Application.UnitTests
{
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public static class IEnumerableExtensions
    {
        public static IEnumerable AsWeakEnumerable(this IEnumerable source)
        {
            foreach (object o in source)
            {
                yield return o;
            }
        }
    }
}

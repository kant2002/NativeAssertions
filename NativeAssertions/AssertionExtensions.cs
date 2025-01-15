namespace NativeAssertions;

public static class AssertionExtensions
{
    //public static StringAssertions Should(this string actualValue)
    //{
    //    return new StringAssertions(actualValue);
    //}
    public static StringCollectionAssertions Should(this IEnumerable<string>? @this)
    {
        return new StringCollectionAssertions(@this);
    }
}

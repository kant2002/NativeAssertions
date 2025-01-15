namespace FluentAssertions;

public static class AssertionExtensions
{
    public static NativeAssertions.StringCollectionAssertions Should(this IEnumerable<string> @this)
    {
        return NativeAssertions.AssertionExtensions.Should(@this);
    }
}

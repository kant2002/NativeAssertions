using System.Globalization;

namespace NativeAssertions.Execution;

public sealed class AssertionScope : IAssertionScope
{
    private static readonly AsyncLocal<AssertionScope> asyncScope = new();
    private bool? comparisonResult;
    private string fallbackIdentifier = "object";
    private Func<string>? failureText;
    public AssertionScope()
    {
        asyncScope.Value = this;
    }

    public static AssertionScope Current
    {
        get
        {
            return asyncScope.Value ?? new AssertionScope();
        }
    }
    public AssertionScope ForCondition(bool condition)
    {
        comparisonResult = condition;

        return this;
    }
    public AssertionScope BecauseOf(string? errorFormat, params object[] textArguments)
    {
        failureText = () =>
        {
            errorFormat = errorFormat ?? string.Empty;

            return textArguments?.Length > 0
                ? string.Format(CultureInfo.InvariantCulture, errorFormat, textArguments)
                : errorFormat;
        };

        return this;
    }
    public AssertionScope WithDefaultIdentifier(string identifier)
    {
        fallbackIdentifier = identifier;
        return this;
    }
    public Continuation FailWith(string message)
    {
        try
        {
            bool failed = comparisonResult != true;

            if (failed)
            {
                string? result = failureText?.Invoke();
                throw new AssertionFailedException(message.Replace("{reason}", result));
            }

            return new Continuation(this, continueAsserting: !failed);
        }
        finally
        {
            comparisonResult = null;
        }
    }
}

using System.Globalization;
using System.Reflection;
using System.Text;

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
        return FailWith(message, new object[0]);
    }

    private string FormatMessage(string message, params object?[]? args)
    {
        if (args is null || args.Length == 0)
        {
            return message;
        }

        for (int i = 0; i < args.Length; i++)
        {
            string formattedValue = FormatValue(args[i]);
            message = message.Replace("{" + i + "}", formattedValue);
        }

        return message;
    }

    private string FormatValue(object? value)
    {
        if (value is Array)
        {
            StringBuilder result = new();
            result.Append("{");
            result.Append(string.Join(",", ((object[]?)value).Select(FormatValue)));
            result.Append("}");
            return result.ToString();
        }

        if (value is string)
        {
            return $"\"{value}\"";
        }

        return value?.ToString() ?? "null";
    }

    public Continuation FailWith(string message, params object?[] args)
    {
        try
        {
            bool failed = comparisonResult != true;

            if (failed)
            {
                string? result = failureText?.Invoke();
                Throw(FormatMessage(message.Replace("{reason}", result), args));
            }

            return new Continuation(this, continueAsserting: !failed);
        }
        finally
        {
            comparisonResult = null;
        }
    }

    static Type? exceptionType;

    private static void Throw(string message)
    {
        if (exceptionType is null)
        {
            var testAssembly = Array.Find(AppDomain.CurrentDomain
                .GetAssemblies(), a => a.FullName.StartsWith("Microsoft.VisualStudio.TestPlatform.TestFramework", StringComparison.OrdinalIgnoreCase));
            exceptionType = testAssembly.GetType("Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException");
        }

        throw (Exception)Activator.CreateInstance(exceptionType, message);
    }
}

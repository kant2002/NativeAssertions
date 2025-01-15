using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions.Execution;

public class Continuation
{
    private readonly AssertionScope sourceScope;
    private readonly bool continueAsserting;

    internal Continuation(AssertionScope sourceScope, bool continueAsserting)
    {
        this.sourceScope = sourceScope;
        this.continueAsserting = continueAsserting;
    }

    /// <summary>
    /// Continues the assertion chain if the previous assertion was successful.
    /// </summary>
    public IAssertionScope Then
    {
        get
        {
            return sourceScope;
        }
    }

    /// <summary>
    /// Provides back-wards compatibility for code that expects <see cref="AssertionScope.FailWith(string, object[])"/> to return a boolean.
    /// </summary>
    public static implicit operator bool(Continuation continuation)
    {
        return continuation.continueAsserting;
    }
}
